using AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.outboundservices.acl;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Profiles.Domain.Model.Repositories;
using AppWeb.HormonalCare.API.Profiles.Domain.Model.ValueObjects;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices;

public class PatientCommandService(
    IPatientRepository patientRepository, ExternalProfileService externalProfileService,IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IPatientCommandService
{
    public async Task<Patient?> Handle(CreatePatientCommand command)
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

            // Crear el paciente
            var patient = new Patient(command, profile);
            await patientRepository.AddAsync(patient);

            // Completar la transacción
            await unitOfWork.CompleteAsync();
            return patient;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Validation error: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while creating the patient: {ex.Message}");
            return null;
        }
    }
    public async Task<Patient?> Handle(UpdatePatientCommand command)
    {
        var patient = await patientRepository.FindByIdAsync(command.Id);
        if (patient == null)
        {
            throw new ArgumentException($"Patient with id {command.Id} does not exist");
        }

        patient.Update(command);
        try
        {
            await unitOfWork.CompleteAsync();
            return patient;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the MedicalExam: {e.Message}");
            return null;
        }

    }
}

