using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface IReasonOfConsultationQueryService
{
    Task<ReasonOfConsultation?> Handle(GetReasonOfConsultationByIdQuery query);
}