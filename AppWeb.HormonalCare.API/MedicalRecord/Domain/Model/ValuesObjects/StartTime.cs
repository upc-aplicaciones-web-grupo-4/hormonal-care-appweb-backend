namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public record StartTime(string startTime)
{
    public StartTime() : this(string.Empty)
    {
    }
}