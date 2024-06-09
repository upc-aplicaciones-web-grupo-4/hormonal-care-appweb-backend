using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;


public partial class Doctor
{
    public Doctor()
    {
        professionalIdentificationNumber = new ProfessionalIdentificationNumber();
        subSpecialty = new SubSpecialty();
        certification = new Certification();
        appointmentFee = 0;
        codeDoctor = new CodeDoctor();
        subscriptionId = 0;
        profileId = new ProfileId();
    }

    public Doctor(string professionalIdentificationNumber, string subSpecialty, string certification, int appointmentFee, int subscriptionId, int profileId)
    {
        this.professionalIdentificationNumber = new ProfessionalIdentificationNumber(professionalIdentificationNumber);
        this.subSpecialty = new SubSpecialty(subSpecialty);
        this.certification = new Certification(certification);
        this.appointmentFee = appointmentFee;
        this.subscriptionId = subscriptionId;
        this.profileId = new ProfileId(profileId);
    }

    public Doctor(CreateDoctorCommand command)
    {
        professionalIdentificationNumber = new ProfessionalIdentificationNumber(command.ProfessionalIdentificationNumber);
        subSpecialty = new SubSpecialty(command.SubSpecialty);
        certification = new Certification(command.Certification);
        appointmentFee = command.AppointmentFee;
        codeDoctor = new CodeDoctor(GenerateCodeDoctor());
        subscriptionId = command.SubscriptionId;
        profileId = new ProfileId(command.ProfileId);
    }

    
    public void UpdateAppointmentFee(UpdateDoctorAppointmentFeeCommand command)
    {
        this.appointmentFee = command.appointmentFee;
    }
    
    public void UpdateSubscriptionId(UpdateDoctorSubscriptionIdCommand command)
    {
        this.subscriptionId = command.subscriptionId;
    }
    
    private string GenerateCodeDoctor()
    {
        return "D" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
    }
    
    public string CodeDoctorValue
    {
        get { return this.codeDoctor.Value; }
    }
    
    public int Id { get; private set; }
    public  ProfessionalIdentificationNumber professionalIdentificationNumber { get; private set; }
    public  SubSpecialty subSpecialty { get; private set; }
    public  Certification certification{ get; private set; }
    public int appointmentFee { get; private set; }
    public  CodeDoctor codeDoctor{ get; private set; }
    public int subscriptionId { get; private set; }
    public ProfileId profileId { get; private set; }
}

