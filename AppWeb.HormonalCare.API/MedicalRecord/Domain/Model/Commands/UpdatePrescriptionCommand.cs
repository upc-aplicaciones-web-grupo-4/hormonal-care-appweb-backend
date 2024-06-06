using System.Runtime.InteropServices.JavaScript;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record UpdatePrescriptionCommand(int Id,int medicationId, int DoctorId, int PatientId, JSType.Date prescriptionDate, String notes);