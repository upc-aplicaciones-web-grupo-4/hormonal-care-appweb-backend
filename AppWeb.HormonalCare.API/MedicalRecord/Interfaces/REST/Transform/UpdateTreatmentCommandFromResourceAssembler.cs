using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class UpdateTreatmentCommandFromResourceAssembler
{
    public static UpdateTreatmentCommand ToCommandFromResource(int id, UpdateTreatmentResource resource)
    {
        return new UpdateTreatmentCommand(id, resource.Description);
    }
}


