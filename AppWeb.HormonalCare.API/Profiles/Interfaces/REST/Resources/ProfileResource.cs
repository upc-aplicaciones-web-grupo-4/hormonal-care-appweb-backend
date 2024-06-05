namespace AppWeb.HormonalCare.API.Profiles.Interfaces.REST.Resources;
public record ProfileResource(
    int Id,
    string FullName,
    string Image,
    string Gender,
    DateTime BirthDate,
    string Phone,
    string Email);