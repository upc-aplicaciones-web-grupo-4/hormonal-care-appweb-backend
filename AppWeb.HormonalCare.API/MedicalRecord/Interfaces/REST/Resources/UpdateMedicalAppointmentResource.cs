namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record UpdateMedicalAppointmentResource
(
    DateTime eventDate,
    string startTime,
    string endTime,
    string tittle,
    string description,
    string doctorEmail,
    string patientEmail
    );