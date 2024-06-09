namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public record EventDate(DateTime eventDate)
{
    public EventDate() : this(DateTime.MinValue)
    {
    }
}