using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class PatientResourceFromEntityAssembler
{
    public static PatientResource ToResourceFromEntity(Patient entity)
    {
        return new PatientResource(
            entity.Id,
            entity.TypeofBloodN
        );
    }
}


