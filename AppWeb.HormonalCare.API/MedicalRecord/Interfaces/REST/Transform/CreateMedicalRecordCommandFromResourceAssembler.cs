using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public static class CreateMedicalRecordCommandFromResourceAssembler
{
    public static CreateMedicalRecordCommand ToCommandFromResource(CreateMedicalRecordResource resource)
    {
        return new CreateMedicalRecordCommand(resource.PatientIdentifier);
    }
}