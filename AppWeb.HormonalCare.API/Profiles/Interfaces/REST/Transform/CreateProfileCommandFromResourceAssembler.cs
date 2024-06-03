using AppWeb.HormonalCare.API.Profiles.Domain.Model.Commands;
using AppWeb.HormonalCare.API.Profiles.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.FirstName, resource.LastName, resource.Email, resource.Street,
            resource.Number, resource.City, resource.PostalCode, resource.Country);
    }
}