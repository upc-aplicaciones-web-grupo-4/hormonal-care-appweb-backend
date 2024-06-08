using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class UpdateReasonOfConsultationCommandFromResourceAssembler
{
    public static UpdateReasonOfConsultationCommand ToCommandFromResource(int id, UpdateReasonOfConsultationResource resource)
    {
        return new UpdateReasonOfConsultationCommand(id, resource.Description, resource.Symptoms);
    }
}