using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class Treatment
{
    public int Id { get; }
    public string Description { get; private set; }
    
    public Treatment()
    {
        Description = string.Empty;
    }

    public Treatment(string description)
    {
        Description = description;
    }
    
    public Treatment(CreateTreatmentCommand command)
    {
        Description = command.Description;
    }
    
    public Treatment UpdateInformation(string description)
    {
        Description = description;
        return this;
    }
}

