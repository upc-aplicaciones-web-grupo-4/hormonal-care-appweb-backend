namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record MedicalAppointmentResource(
    int Id,
    DateTime eventDate,
    string startTime,
    string endTime,
    string tittle,
    string description,
    string doctorEmail,
    string patientEmail
    );