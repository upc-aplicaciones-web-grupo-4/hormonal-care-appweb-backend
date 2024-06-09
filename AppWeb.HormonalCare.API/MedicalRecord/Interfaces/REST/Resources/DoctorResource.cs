namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record DoctorResource
(
    int Id,
    string ProfessionalIdentificationNumber,
    string SubSpecialty,
    string Certification,
    int AppointmentFee,
    int SubscriptionId,
    int ProfileId,
    string CodeDoctorValue  // Agrega esta línea
);