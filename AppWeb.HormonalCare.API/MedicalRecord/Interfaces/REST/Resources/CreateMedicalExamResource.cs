namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record CreateMedicalExamResource(
    string Name,
    int TypeExamIdentifier);