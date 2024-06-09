namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record CreateDoctorCommand(
    string ProfessionalIdentificationNumber,
    string SubSpecialty,
    string Certification,
    int AppointmentFee,
    int SubscriptionId,
    int ProfileId
);


