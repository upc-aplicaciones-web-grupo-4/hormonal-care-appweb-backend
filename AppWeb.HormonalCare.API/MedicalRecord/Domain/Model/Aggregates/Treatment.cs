using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class Treatment
{
    public Treatment()
    {
        Description = string.Empty;
        MedicalRecordId = 0;
    }

    public Treatment(string description, int medicalRecordId): this()
    {
        Description = description;
        MedicalRecordId = medicalRecordId;
    }
    
    public Treatment(CreateTreatmentCommand command, MedicalRecord medicalRecord)
    {
        Description = command.Description;
        MedicalRecord = medicalRecord;
    }
    
    public void Update(UpdateTreatmentCommand command, MedicalRecord medicalRecord)
    {
        Description = command.Description;
        MedicalRecord = medicalRecord;
    }
    
    public int Id { get; }
    public string Description { get; private set; }
    public MedicalRecord MedicalRecord { get; private set; }
    public int MedicalRecordId { get; private set; }
}

