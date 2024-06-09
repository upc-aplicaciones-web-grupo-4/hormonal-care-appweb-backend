using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public static class ReasonOfConsultationResourceFromEntityAssembler
{
    public static ReasonOfConsultationResource ToResourceFromEntity(ReasonOfConsultation entity)
    {
        return new ReasonOfConsultationResource(entity.Id, entity.Description, entity.Symptoms);
    }
}