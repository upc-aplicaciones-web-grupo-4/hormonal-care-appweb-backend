using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices;

public class DoctorCommandService
    (IDoctorRepository doctorRepository, IUnitOfWork unitOfWork) : IDoctorCommandService
{
    public async Task<Doctor?> Handle(CreateDoctorCommand command)
    {
        var doctor = new Doctor(command);
        try
        {
            await doctorRepository.AddAsync(doctor);
            await unitOfWork.CompleteAsync();
            return doctor;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the doctor: {e.Message}");
            return null;
        }
    }

    public async Task<Doctor?> Handle(UpdateDoctorAppointmentFeeCommand command)
    {
        var doctor = await doctorRepository.FindByIdAsync(command.id);
        if (doctor == null)
        {
            throw new ArgumentException($"Doctor with id {command.id} does not exist");
        }

        doctor.UpdateAppointmentFee(command);
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
    
    public async Task<Doctor?> Handle(UpdateDoctorSubscriptionIdCommand command)
    {
        var doctor = await doctorRepository.FindByIdAsync(command.id);
        if (doctor == null)
        {
            throw new ArgumentException($"Doctor with id {command.id} does not exist");
        }

        doctor.UpdateSubscriptionId(command);
        try
        {
            await unitOfWork.CompleteAsync();
            return doctor;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the Doctor's subscription: {e.Message}");
            return null;
        }

    }
}
