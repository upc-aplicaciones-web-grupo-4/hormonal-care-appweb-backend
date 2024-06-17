using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;
using AppWeb.HormonalCare.API.Profiles.Interfaces.REST.Transform;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class PatientResourceFromEntityAssembler
{
    public static PatientResource ToResourceFromEntity(Patient entity)
    {
        return new PatientResource(
            entity.Id,
            entity.TypeofBloodN,
            entity.RecordId,
            ProfileResourceFromEntityAssembler.ToResourceFromEntity(entity.Profile)
            
        );
    }
}