using AppWeb.HormonalCare.API.Profiles.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record DoctorResource
(
    int Id,
    int ProfessionalIdentificationNumber,
    string SubSpecialty,
    string Certification,
    int AppointmentFee,
    int SubscriptionId,
    ProfileResource ProfileId,
    string CodeDoctorValue  
);