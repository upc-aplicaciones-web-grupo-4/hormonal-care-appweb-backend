using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices;


public class TreatmentCommandService(
    ITreatmentRepository treatmentRepository, 
    IMedicalRecordRepository medicalRecordRepository,
    IUnitOfWork unitOfWork
    ): ITreatmentCommandService
{
    public async Task<Treatment?> Handle(CreateTreatmentCommand command)
    {
        var medicalRecord = await medicalRecordRepository.FindByIdAsync(command.MedicalRecordId);
        if (medicalRecord == null)
        {
            throw new Exception("MedicalRecord not found");
        }
        
        var treatment = new Treatment(command, medicalRecord);
        try
        {
            await treatmentRepository.AddAsync(treatment);
            await unitOfWork.CompleteAsync();
            return treatment;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the treatment: {e.Message}");
            return null;
        }
    }
    
    public async Task<Treatment?> Handle(UpdateTreatmentCommand command)
    {
        
        var medicalRecord = await medicalRecordRepository.FindByIdAsync(command.MedicalRecordId);
        if (medicalRecord == null)
        {
            throw new Exception("MedicalRecord not found");
        }
        
        var treatment = await treatmentRepository.FindByIdAsync(command.Id);
        if (treatment == null)
        {
            throw new ArgumentException($"Treatment with id {command.Id} does not exist");
        }
        
        treatment.Update(command, medicalRecord);
        try
        {
            await unitOfWork.CompleteAsync();
            return treatment;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the treatment: {e.Message}");
            return null;
        }
    }
}