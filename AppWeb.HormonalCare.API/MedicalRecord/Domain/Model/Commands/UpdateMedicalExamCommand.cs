namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record UpdateMedicalExamCommand(
    int Id,
    string Name,
    int TypeExamId,
    int MedicalRecordId);