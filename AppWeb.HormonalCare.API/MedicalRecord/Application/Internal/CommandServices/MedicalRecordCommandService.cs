using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices;

public class MedicalRecordCommandService (IMedicalRecordRepository medicalRecordRepository, IReasonOfConsultationRepository reasonOfConsultationRepository, IUnitOfWork unitOfWork): IMedicalRecordCommandService
{
    public async Task<Domain.Model.Aggregates.MedicalRecord?> Handle(CreateMedicalRecordCommand command)
    {
        try
        {
            var reasonOfConsultation = new ReasonOfConsultation();
            await reasonOfConsultationRepository.AddAsync(reasonOfConsultation);
            await unitOfWork.CompleteAsync(); 

            var medicalRecord = new Domain.Model.Aggregates.MedicalRecord(reasonOfConsultation);
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