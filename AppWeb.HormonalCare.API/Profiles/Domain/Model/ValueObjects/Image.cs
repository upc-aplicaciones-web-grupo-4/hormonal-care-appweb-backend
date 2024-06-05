namespace AppWeb.HormonalCare.API.Profiles.Domain.Model.ValueObjects;

public record Image(string Url)
{
    public Image() : this(string.Empty)
    {
    }
}