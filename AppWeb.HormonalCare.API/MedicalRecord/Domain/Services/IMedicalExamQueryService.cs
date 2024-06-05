using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface IMedicalExamQueryService
{
    Task<IEnumerable<MedicalExam>> Handle(GetAllMedicalExamsQuery query);
    Task<MedicalExam?> Handle(GetMedicalExamByNameQuery query);
    Task<MedicalExam?> Handle(GetMedicalExamByIdQuery query);
}