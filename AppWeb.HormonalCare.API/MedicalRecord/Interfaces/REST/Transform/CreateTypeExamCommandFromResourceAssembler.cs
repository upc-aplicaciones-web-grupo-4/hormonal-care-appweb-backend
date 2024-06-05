using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public static class CreateTypeExamCommandFromResourceAssembler
{
    public static CreateTypeExamCommand ToCommandFromResource(CreateTypeExamResource resource)
    {
        return new CreateTypeExamCommand(resource.Name);
    }
}