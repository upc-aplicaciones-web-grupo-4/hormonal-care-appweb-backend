using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public static class PrescriptionResourceFromEntityAssembler
{
    public static PrescriptionResource ToResourceFromEntity(Prescription entity)
    {
        return new PrescriptionResource(
            entity.Id, 
            entity.DoctorId,
            entity.PatientId,
            entity.PrescriptionDate,
            entity.Notes
        );
    }
}