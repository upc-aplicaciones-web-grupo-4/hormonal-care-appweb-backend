using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices;


public class TypeExamQueryService(ITypeExamRepository typeExamRepository) : ITypeExamQueryService
{

    public async Task<IEnumerable<TypeExam>> Handle(GetAllTypesExamsQuery query)
    {
        return await typeExamRepository.ListAsync();
    }

    public async Task<TypeExam?> Handle(GetTypeExamByNameQuery query)
    {
        return await typeExamRepository.FindTypeExamByNameAsync(query.Name);
    }
    public async Task<TypeExam?> Handle(GetTypeExamByIdQuery query)
    {
        return await typeExamRepository.FindByIdAsync(query.TypeExamId);
    }

}