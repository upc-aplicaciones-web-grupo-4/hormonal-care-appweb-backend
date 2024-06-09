namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record UpdateDoctorSubscriptionIdCommand(int id, int subscriptionId);