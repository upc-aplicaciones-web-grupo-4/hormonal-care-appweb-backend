namespace AppWeb.HormonalCare.API.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(
    string FirstName,
    string LastName,
    string Image,
    string Gender,
    DateTime BirthDate,
    string Phone,
    string Email);