using AppWeb.HormonalCare.API.Publishing.Domain.Model.Commands;
using AppWeb.HormonalCare.API.Publishing.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.Publishing.Interfaces.REST.Transform;

public static class CreateTutorialCommandFromResourceAssembler
{
    public static CreateTutorialCommand ToCommandFromResource(CreateTutorialResource resource)
    {
        return new CreateTutorialCommand(resource.Title, resource.Summary, resource.CategoryId);
    }
}