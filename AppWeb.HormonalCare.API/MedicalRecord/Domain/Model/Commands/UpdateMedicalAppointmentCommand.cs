namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record UpdateMedicalAppointmentCommand
(
    int id,
    DateTime eventDate,
    string startTime,
    string endTime,
    string tittle,
    string description,
    string doctorEmail,
    string patientEmail
    );