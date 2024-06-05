using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices;

public class TypeExamCommandService(ITypeExamRepository typeExamRepository, IUnitOfWork unitOfWork) : ITypeExamCommandService
{
    

    public async Task<TypeExam?> Handle(CreateTypeExamCommand command)
    {
        var typeExam = new TypeExam(command);
        try
        {
            await typeExamRepository.AddAsync(typeExam);
            await unitOfWork.CompleteAsync();
            return typeExam;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the TypeExam: {e.Message}");
            return null;
        }
    }
}