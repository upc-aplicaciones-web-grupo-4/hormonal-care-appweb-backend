using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices;

public class MedicalAppointmentCommandService (IMedicalAppointmentRepository medicalAppointmentRepository, IUnitOfWork unitOfWork) : IMedicalAppointmentCommandService
{
    public async Task<MedicalAppointment?> Handle(CreateMedicalAppointmentCommand command)
    {
        var medicalAppointment = new MedicalAppointment(command);
        try
        {
            await medicalAppointmentRepository.AddAsync(medicalAppointment);
            await unitOfWork.CompleteAsync();
            return medicalAppointment;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the medical appointment: {e.Message}");
            return null;
        }
    }
    
    public async Task<MedicalAppointment?> Handle(UpdateMedicalAppointmentCommand command)
    {
        var medicalAppointment = await medicalAppointmentRepository.FindByIdAsync(command.id);
        if (medicalAppointment == null)
        {
            throw new ArgumentException($"Medical appointment with id {command.id} does not exist");
        }

        medicalAppointment.UpdateInformation(command);

        try
        {
            await unitOfWork.CompleteAsync();  
            return medicalAppointment;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the medical appointment: {e.Message}");
            return null;
        }
    }
}

