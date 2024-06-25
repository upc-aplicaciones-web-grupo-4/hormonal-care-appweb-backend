using AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.outboundservices.acl;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Profiles.Domain.Model.Repositories;
using AppWeb.HormonalCare.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices;

public class DoctorCommandService
    (IDoctorRepository doctorRepository, ExternalProfileService externalProfileService,IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IDoctorCommandService
{
    public async Task<Doctor?> Handle(CreateDoctorCommand command)
    {
        try
        {
            // Verificar si el perfil ya existe
            var profileId = await externalProfileService.FetchProfileIdByEmail(command.Email);

            // Si el perfil no existe, crear uno nuevo
            if (profileId == null)
            {
                profileId = await externalProfileService.CreateProfile(
                    command.FirstName,
                    command.LastName,
                    command.Image,
                    command.Gender,
                    command.BirthDate,
                    command.Phone,
                    command.Email);
            }
            else
            {
                throw new ArgumentException("Email already exists");
            }

            // Buscar el perfil recién creado
            var profile = await profileRepository.FindByIdAsync(profileId.Value);
            if (profile == null)
            {
                throw new InvalidOperationException("Profile not found after creation.");
            }

            // Crear el doctor
            var doctor = new Doctor(command, profile);
            await doctorRepository.AddAsync(doctor);

            // Completar la transacción
            await unitOfWork.CompleteAsync();
            return doctor;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Validation error: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while creating the doctor: {ex.Message}");
            return null;
        }
    }

    public async Task<Doctor?> Handle(UpdateDoctorCommand command)
    {
        var doctor = await doctorRepository.FindByIdAsync(command.id);
        if (doctor == null)
        {
            throw new ArgumentException($"Doctor with id {command.id} does not exist");
        }

        doctor.Update(command);
        try
        {
            await unitOfWork.CompleteAsync();
            return doctor;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the Doctor's appointment: {e.Message}");
            return null;
        }

    }
}
