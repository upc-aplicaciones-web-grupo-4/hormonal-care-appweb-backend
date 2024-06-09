using System.Runtime.InteropServices.JavaScript;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record UpdatePrescriptionCommand(int Id, int DoctorId, int PatientId, DateTime PrescriptionDate, String Notes);