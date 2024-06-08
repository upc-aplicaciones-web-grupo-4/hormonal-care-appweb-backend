using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface IMedicalExamCommandService
{
    Task<MedicalExam?> Handle(CreateMedicalExamCommand command);
    Task<MedicalExam?> Handle(UpdateMedicalExamCommand command);
}