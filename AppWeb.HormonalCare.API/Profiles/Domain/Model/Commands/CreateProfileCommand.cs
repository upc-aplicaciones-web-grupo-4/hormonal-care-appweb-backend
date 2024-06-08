namespace AppWeb.HormonalCare.API.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(
    string FirstName, 
    string LastName, 
    string Image, 
    string Gender, 
    DateTime BirthDate, 
    string Phone, 
    string Email
);