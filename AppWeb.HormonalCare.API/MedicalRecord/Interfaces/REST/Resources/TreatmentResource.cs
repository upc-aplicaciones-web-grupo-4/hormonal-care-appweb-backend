namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record TreatmentResource(int Id, string Description, MedicalRecordResource MedicalRecord);