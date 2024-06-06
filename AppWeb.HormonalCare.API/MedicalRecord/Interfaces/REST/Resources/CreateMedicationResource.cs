namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record CreateMedicationResource(int prescriptionId, int medicationTypeId, string drugName, int quantity, string concentration, int frequency, string duration);