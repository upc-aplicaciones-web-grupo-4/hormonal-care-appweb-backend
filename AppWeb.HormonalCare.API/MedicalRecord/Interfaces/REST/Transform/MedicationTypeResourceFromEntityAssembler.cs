using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public static class MedicationTypeResourceFromEntityAssembler
{
    public static MedicationTypeResource ToResourceFromEntity(MedicationType entity)
    {
        return new MedicationTypeResource(
            entity.Id, 
            entity.TypeName
        );
    }
}