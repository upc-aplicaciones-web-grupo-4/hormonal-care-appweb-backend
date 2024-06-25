namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record CreateTreatmentResource(
    string Description,
    int MedicalRecordIdentifier);