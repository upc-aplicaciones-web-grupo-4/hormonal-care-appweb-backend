using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;
using AppWeb.HormonalCare.API.Profiles.Domain.Model.Aggregates;

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
        profileId = 0;
    }
    
    public Doctor(
        int professionalIdentificationNumber, 
        string subSpecialty, 
        string certification, 
        int appointmentFee, 
        int subscriptionId, 
        int profileId)
    {
        this.professionalIdentificationNumber = new ProfessionalIdentificationNumber(professionalIdentificationNumber);
        this.subSpecialty = new SubSpecialty(subSpecialty);
        this.certification = new Certification(certification);
        this.appointmentFee = appointmentFee;
        this.subscriptionId = subscriptionId;
        this.profileId = profileId;
        this.codeDoctor = new CodeDoctor();
    }

    public Doctor(CreateDoctorCommand command, Profile profile)
    {
        this.professionalIdentificationNumber = new ProfessionalIdentificationNumber(command.ProfessionalIdentificationNumber);
        this.subSpecialty = new SubSpecialty(command.SubSpecialty);
        this.certification = new Certification(command.Certification);
        this.appointmentFee = command.AppointmentFee;
        this.codeDoctor = new CodeDoctor(GenerateCodeDoctor());
        this.subscriptionId = command.SubscriptionId;
        this.profile = profile;
    }

    
    public void Update(UpdateDoctorCommand command)
    {
        this.appointmentFee = command.appointmentFee;
        this.subscriptionId = command.subscriptionId;
    }
    
    private string GenerateCodeDoctor()
    {
        return "D" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
    
   
    public int Id { get; private set; }
    public  ProfessionalIdentificationNumber professionalIdentificationNumber { get; private set; }
    public  SubSpecialty subSpecialty { get; private set; }
    public  Certification certification{ get; private set; }
    public int appointmentFee { get; private set; }
    public  CodeDoctor codeDoctor{ get; private set; }
    public int subscriptionId { get; private set; }
    public Profile profile { get; private set; }
    public int profileId { get; private set; }
    
    public int ProfessionalIdentificationNumberValue => professionalIdentificationNumber.professionalIdentificationNumber;
    public string SubSpecialtyValue => subSpecialty.subSpecialty;
    public string CertificationValue => certification.certification;
    public string CodeDoctorValue => codeDoctor.codeDoctor;
    public int SubscriptionIdValue => subscriptionId;
    public int AppointmentFeeValue => appointmentFee;
    
}

