namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record UpdateReasonOfConsultationCommand(int Id, string Description, string Symptoms);