using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class ReasonOfConsultation
{
    public ReasonOfConsultation()
    {
        Description = string.Empty;
        Symptoms = string.Empty;
    }
    
    public ReasonOfConsultation(string description, string symptoms)
    {
        Description = description;
        Symptoms = symptoms;
    }

    public ReasonOfConsultation(CreateReasonOfConsultationCommand command)
    {
        Description = command.Description;
        Symptoms = command.Symptoms;
    }
    
    public int Id { get; }
    public string Description { get; private set; }
    public string Symptoms { get; private set; }
    
    public ReasonOfConsultation UpdateInformation (string description, string symptoms)
    {
        Description = description;
        Symptoms = symptoms;
        return this;
    }
}