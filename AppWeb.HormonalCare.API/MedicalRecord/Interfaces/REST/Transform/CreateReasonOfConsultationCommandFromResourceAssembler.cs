using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public static class CreateReasonOfConsultationCommandFromResourceAssembler
{
    public static CreateReasonOfConsultationCommand ToCommandFromResource(CreateReasonOfConsultationResource resource)
    {
        return new CreateReasonOfConsultationCommand(resource.Description, resource.Symptoms);
    }
}