using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class UpdateDoctorSubscriptionIdCommandFromResourceAssembler
{
    public static UpdateDoctorSubscriptionIdCommand ToCommandFromResource(int id, UpdateDoctorSubscriptionIdResource resource)
    {
        return new UpdateDoctorSubscriptionIdCommand(id, resource.subscriptionId);
    }
}