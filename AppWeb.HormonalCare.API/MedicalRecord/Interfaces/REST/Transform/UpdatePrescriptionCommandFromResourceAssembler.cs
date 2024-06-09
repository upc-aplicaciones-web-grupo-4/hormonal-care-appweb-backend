using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class UpdatePrescriptionCommandFromResourceAssembler
{
    public static UpdatePrescriptionCommand ToCommandFromResource(int id, UpdatePrescriptionResource resource)
    {
        return new UpdatePrescriptionCommand(id, resource.DoctorId, resource.PatientId, resource.PrescriptionDate, resource.Notes);
    }

}