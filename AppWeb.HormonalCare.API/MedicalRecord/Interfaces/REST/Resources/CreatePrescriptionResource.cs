namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record CreatePrescriptionResource(int DoctorId, int PatientId, DateTime prescriptionDate, string notes);