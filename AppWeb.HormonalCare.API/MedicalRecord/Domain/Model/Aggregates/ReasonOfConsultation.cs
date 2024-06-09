using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class ReasonOfConsultation
{
    public int Id { get; }
    public string Description { get; private set; }
    public string Symptoms { get; private set; }

    //public MedicalRecord MedicalRecord { get; set; }
    
    public ReasonOfConsultation()
    {
        //MedicalRecord = new MedicalRecord();
        Description = string.Empty;
        Symptoms = string.Empty;
    }

    public ReasonOfConsultation(string description, string symptoms)
    {
        //MedicalRecord = new MedicalRecord();
        Description = description;
        Symptoms = symptoms;
    }

    public ReasonOfConsultation(CreateReasonOfConsultationCommand command)
    {
        //MedicalRecord = new MedicalRecord();
        Description = command.Description;
        Symptoms = command.Symptoms;
    }

    public ReasonOfConsultation UpdateInformation(string description, string symptoms)
    {
        Description = description;
        Symptoms = symptoms;
        return this;
    }

}   