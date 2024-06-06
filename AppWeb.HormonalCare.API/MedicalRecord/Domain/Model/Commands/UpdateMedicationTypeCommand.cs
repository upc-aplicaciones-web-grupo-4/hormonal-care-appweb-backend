namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record UpdateMedicationTypeCommand (int Id,int medicationId, int medicationTypeId, String typeName);