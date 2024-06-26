using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class ReasonOfConsultation
{
    public int Id { get; }
    public string Description { get; private set; }
    public string Symptoms { get; private set; }
    
    
 
    
    public ReasonOfConsultation()
    {
        Description = string.Empty;
        Symptoms = string.Empty;
        MedicalRecordId = 0;
    }

    public ReasonOfConsultation(string description, string symptoms, int medicalRecordId)
    {
        Description = description;
        Symptoms = symptoms;
        MedicalRecordId = medicalRecordId;
    }

    public ReasonOfConsultation(CreateReasonOfConsultationCommand command, MedicalRecord medicalRecord)
    {
        Description = command.Description;
        Symptoms = command.Symptoms;
        MedicalRecord = medicalRecord;
    }

    public ReasonOfConsultation UpdateInformation(string description, string symptoms)
    {
        Description = description;
        Symptoms = symptoms;
        return this;
    }
    public MedicalRecord MedicalRecord { get; private set; }
    
    public int MedicalRecordId { get; private set; }

}   