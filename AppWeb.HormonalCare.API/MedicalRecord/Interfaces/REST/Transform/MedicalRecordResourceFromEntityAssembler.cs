using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public static class MedicalRecordResourceFromEntityAssembler
{
    public static MedicalRecordResource ToResourceFromEntity(Domain.Model.Aggregates.MedicalRecord entity)
    {
        return new MedicalRecordResource(entity.Id, PatientResourceFromEntityAssembler .ToResourceFromEntity(entity.Patient));
    }
}