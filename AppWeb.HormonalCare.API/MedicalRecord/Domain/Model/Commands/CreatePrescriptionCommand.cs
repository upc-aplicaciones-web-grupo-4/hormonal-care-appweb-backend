using System.Runtime.InteropServices.JavaScript;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record CreatePrescriptionCommand(int DoctorId, int PatientId, DateTime PrescriptionDate, String Notes);
