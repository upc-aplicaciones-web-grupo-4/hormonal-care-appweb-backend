using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface IReasonOfConsultationCommandService
{
    Task<ReasonOfConsultation?> Handle(CreateReasonOfConsultationCommand command);
    Task<ReasonOfConsultation?> Handle(UpdateReasonOfConsultationCommand command);
}