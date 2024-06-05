using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices;

public class MedicalExamQueryService(IMedicalExamRepository medicalExamRepository) : IMedicalExamQueryService
{

    public async Task<IEnumerable<MedicalExam>> Handle(GetAllMedicalExamsQuery query)
    {
        return await medicalExamRepository.ListAsync();
    }

    public async Task<MedicalExam?> Handle(GetMedicalExamByNameQuery query)
    {
        return await medicalExamRepository.FindMedicalExamByNameAsync(query.Name);
    }
    public async Task<MedicalExam?> Handle(GetMedicalExamByIdQuery query)
    {
        return await medicalExamRepository.FindByIdAsync(query.MedicalExamId);
    }
}