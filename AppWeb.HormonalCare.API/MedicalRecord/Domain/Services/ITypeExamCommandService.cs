using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface ITypeExamCommandService
{
    Task<TypeExam?> Handle(CreateTypeExamCommand command);
}