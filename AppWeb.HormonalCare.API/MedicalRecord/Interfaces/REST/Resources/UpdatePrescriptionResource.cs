namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record UpdatePrescriptionResource(int DoctorId, int PatientId, DateTime PrescriptionDate, string Notes);