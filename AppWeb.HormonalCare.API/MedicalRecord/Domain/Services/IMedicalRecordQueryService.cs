using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface IMedicalRecordQueryService
{
    Task<Model.Aggregates.MedicalRecord?> Handle(GetMedicalRecordByIdQuery query);

}