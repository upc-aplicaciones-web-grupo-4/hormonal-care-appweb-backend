namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record UpdateMedicalExamResource(
    string Name,
    int TypeExamIdentifier,
    int MedicalRecordIdentifier);