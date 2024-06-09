using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public static class MedicationResourceFromEntityAssembler
{
    public static MedicationResource ToResourceFromEntity(Medication entity)
    {
        return new MedicationResource(
            entity.Id, 
            PrescriptionResourceFromEntityAssembler.ToResourceFromEntity(entity.Prescription),
            MedicationTypeResourceFromEntityAssembler.ToResourceFromEntity(entity.MedicationType),
            entity.DrugName,
            entity.Quantity,
            entity.Concentration,
            entity.Frequency,
            entity.Duration
        );
    }
}

