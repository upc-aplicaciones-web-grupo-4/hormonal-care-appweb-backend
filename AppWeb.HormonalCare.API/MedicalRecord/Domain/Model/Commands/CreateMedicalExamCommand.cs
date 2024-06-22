namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record CreateMedicalExamCommand(
    string Name,
    int TypeExamId,
    int MedicalRecordId
    );