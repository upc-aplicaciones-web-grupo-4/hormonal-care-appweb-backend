namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record CreateTreatmentCommand(
    string Description,
    int MedicalRecordId
    );
