namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record CreateReasonOfConsultationCommand(string Description, string Symptoms, int MedicalRecordId);