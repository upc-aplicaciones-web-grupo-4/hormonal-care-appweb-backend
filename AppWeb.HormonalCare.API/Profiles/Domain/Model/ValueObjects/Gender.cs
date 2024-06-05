namespace AppWeb.HormonalCare.API.Profiles.Domain.Model.ValueObjects;

public record Gender(string Value)
{
    public Gender() : this(string.Empty)
    {
    }
}