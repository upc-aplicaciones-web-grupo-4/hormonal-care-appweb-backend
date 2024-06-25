namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record CreateReasonOfConsultationResource(string Description, string Symptoms, int MedicalRecordIdentifier);