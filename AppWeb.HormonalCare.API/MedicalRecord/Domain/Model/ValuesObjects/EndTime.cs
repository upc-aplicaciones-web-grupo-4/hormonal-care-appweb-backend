namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public record EndTime(string endTime)
{
    public EndTime() : this(string.Empty) 
    { }
}

