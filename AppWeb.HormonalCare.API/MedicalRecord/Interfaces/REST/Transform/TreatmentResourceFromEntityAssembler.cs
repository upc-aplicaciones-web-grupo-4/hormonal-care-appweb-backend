using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class TreatmentResourceFromEntityAssembler
{
    public static TreatmentResource ToResourceFromEntity(Treatment entity)
    {
        return new TreatmentResource(entity.Id, entity.Description, MedicalRecordResourceFromEntityAssembler.ToResourceFromEntity(entity.MedicalRecord));
    }
}
