using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public static class CreateMedicalExamCommandFromResourceAssembler
{
    public static CreateMedicalExamCommand ToCommandFromResource(CreateMedicalExamResource resource)
    {
        return new CreateMedicalExamCommand(resource.Name, resource.TypeExamIdentifier, resource.MedicalRecordIdentifier);
    }
}