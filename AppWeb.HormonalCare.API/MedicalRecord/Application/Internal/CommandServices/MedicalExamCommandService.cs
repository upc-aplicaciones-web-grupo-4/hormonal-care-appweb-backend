using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices;

public class MedicalExamCommandService(IMedicalExamRepository medicalExamRepository, ITypeExamRepository typeExamRepository, IMedicalRecordRepository medicalRecordRepository, IUnitOfWork unitOfWork) : IMedicalExamCommandService
{
    

    public async Task<MedicalExam?> Handle(CreateMedicalExamCommand command)
    {
        var typeExam = await typeExamRepository.FindByIdAsync(command.TypeExamId);
        if (typeExam == null)
        {
            throw new Exception("TypeExam not found");
        }
        var medicalRecord = await medicalRecordRepository.FindByIdAsync(command.MedicalRecordId);
        if (medicalRecord == null)
        {
            throw new Exception("MedicalRecord not found");
        }
        var medicalExam = new MedicalExam(command, typeExam, medicalRecord);
        try
        {
            await medicalExamRepository.AddAsync(medicalExam);
            await unitOfWork.CompleteAsync();
            return medicalExam;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the MedicalExam: {e.Message}");
            return null;
        }
    }
    
    public async Task<MedicalExam?> Handle(UpdateMedicalExamCommand command)
    {
        var medicalExam = await medicalExamRepository.FindByIdAsync(command.Id);
        if (medicalExam == null)
        {
            throw new Exception("MedicalExam not found");
        }
        var typeExam = await typeExamRepository.FindByIdAsync(command.TypeExamId);
        if (typeExam == null)
        {
            throw new Exception("TypeExam not found");
        }
        var medicalRecord = await medicalRecordRepository.FindByIdAsync(command.MedicalRecordId);
        if (medicalRecord == null)
        {
            throw new Exception("MedicalRecord not found");
        }
        
        medicalExam.Update(command, typeExam, medicalRecord);
        try
        {
            await unitOfWork.CompleteAsync();
            return medicalExam;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the MedicalExam: {e.Message}");
            return null;
        }
    }
}