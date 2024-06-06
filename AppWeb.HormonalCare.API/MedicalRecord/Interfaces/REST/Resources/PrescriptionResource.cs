namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record PrescriptionResource(
    int Id,int DoctorId, int PatientId, DateTime prescriptionDate, string notes
    );