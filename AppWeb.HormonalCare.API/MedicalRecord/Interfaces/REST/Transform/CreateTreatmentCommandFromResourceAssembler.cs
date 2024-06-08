using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class CreateTreatmentCommandFromResourceAssembler
{
    public static CreateTreatmentCommand ToCommandFromResource(CreateTreatmentResource resource)
    {
        return new CreateTreatmentCommand(resource.Description);
    }
}

/*

public static CreateReasonOfConsultationCommand ToCommandFromResource(CreateReasonOfConsultationResource resource)
    {
        return new CreateReasonOfConsultationCommand(resource.Description, resource.Symptoms);
    }
*/