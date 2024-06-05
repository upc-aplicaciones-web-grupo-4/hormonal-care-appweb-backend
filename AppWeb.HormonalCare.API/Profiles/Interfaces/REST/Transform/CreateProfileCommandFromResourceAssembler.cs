using AppWeb.HormonalCare.API.Profiles.Domain.Model.Commands;
using AppWeb.HormonalCare.API.Profiles.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(
            resource.FirstName,
            resource.LastName,
            resource.Image,
            resource.Gender,
            resource.BirthDate,
            resource.Phone,
            resource.Email
        );
    }
}