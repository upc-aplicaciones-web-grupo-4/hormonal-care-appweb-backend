namespace AppWeb.HormonalCare.API.Profiles.Domain.Model.ValueObjects;

public record BirthDate(DateTime Value)
{
    public BirthDate() : this(DateTime.MinValue)
    {
    }
}