namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record UpdateTreatmentCommand(
    int Id, 
    string Description,
    int MedicalRecordId
    );
