using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;
using AppWeb.HormonalCare.API.Profiles.Interfaces.REST.Transform;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class DoctorResourceFromEntityAssembler
{
    public static DoctorResource ToResourceFromEntity(Doctor entity)
    {
        return new DoctorResource(
            entity.Id,
            entity.professionalIdentificationNumber.professionalIdentificationNumber,
            entity.subSpecialty.subSpecialty,
            entity.certification.certification,
            entity.appointmentFee,
            entity.subscriptionId,
            ProfileResourceFromEntityAssembler.ToResourceFromEntity(entity.profile),
            entity.CodeDoctorValue
        );
    }
}