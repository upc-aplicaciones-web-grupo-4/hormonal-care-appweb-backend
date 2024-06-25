namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record UpdateTreatmentResource(
    string Description, 
    int MedicalRecordIdentifier);