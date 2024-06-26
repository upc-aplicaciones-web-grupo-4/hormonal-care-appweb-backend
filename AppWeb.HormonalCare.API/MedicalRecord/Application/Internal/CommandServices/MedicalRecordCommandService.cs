using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices;

public class MedicalRecordCommandService (IMedicalRecordRepository medicalRecordRepository, IPatientRepository patientRepository,  IUnitOfWork unitOfWork): IMedicalRecordCommandService
{
    public async Task<Domain.Model.Aggregates.MedicalRecord?> Handle(CreateMedicalRecordCommand command)
    {
        var patient = await patientRepository.FindByIdAsync(command.PatientId);
        if (patient == null)
        {
            throw new Exception("Patient not found");
        }
        
        var medicalRecord = new Domain.Model.Aggregates.MedicalRecord(patient);
        try
        {
            await medicalRecordRepository.AddAsync(medicalRecord);
            await unitOfWork.CompleteAsync(); 

            return medicalRecord;
        } 
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the medical record: {e.Message}");
            return null;
        }
    }
}