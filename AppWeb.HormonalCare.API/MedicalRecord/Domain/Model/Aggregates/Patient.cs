using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;
using AppWeb.HormonalCare.API.Profiles.Domain.Model.Aggregates;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class Patient
{
    public Patient()
    {
        TypeofBloodName = new TypeofBlood();
        PatientRecordId = new PatientRecord();
        ProfileId = 0;
    }

    public Patient(string typeofBloodName, string patientRecordId, int profileId): this()
    {
        TypeofBloodName = new TypeofBlood(typeofBloodName);
        PatientRecordId = new PatientRecord(patientRecordId);
        ProfileId = profileId;
    }

    public Patient(CreatePatientCommand command, Profile profile)
    {
        TypeofBloodName = new TypeofBlood(command.TypeofBloodName);
        PatientRecordId = new PatientRecord();
        Profile = profile;
    }
    
    public void Update(UpdatePatientCommand command)
    {
        TypeofBloodName = new TypeofBlood(command.TypeofBloodName);
    }
    
    
    public int Id { get; private set; }
    public TypeofBlood TypeofBloodName { get; private set; }
    
    
    //
    public PatientRecord PatientRecordId { get; set; }
    
    public Profile Profile { get; private set; }
    public int ProfileId { get; private set; }
    //
    
    
    public string TypeofBloodN => TypeofBloodName.TypeofBloodN;
    public string RecordId => PatientRecordId.RecordId;

    public ICollection<MedicalRecord> MedicalRecords { get; private set; }

}