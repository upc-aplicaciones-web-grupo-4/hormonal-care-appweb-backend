using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface ITypeExamQueryService
{
    Task<IEnumerable<TypeExam>> Handle(GetAllTypesExamsQuery query);
    Task<TypeExam?> Handle(GetTypeExamByNameQuery query);
    Task<TypeExam?> Handle(GetTypeExamByIdQuery query);
}