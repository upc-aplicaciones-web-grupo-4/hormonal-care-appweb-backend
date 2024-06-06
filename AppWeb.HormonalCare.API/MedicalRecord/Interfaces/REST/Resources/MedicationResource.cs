namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record MedicationResource(
    int Id,PrescriptionResource prescription, MedicationTypeResource medicationType, string drugName, int quantity, string concentration, int frequency, string duration
    );