using AppWeb.HormonalCare.API.Publishing.Domain.Model.Commands;
using AppWeb.HormonalCare.API.Publishing.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.Publishing.Interfaces.REST.Transform;

public static class CreateCategoryCommandFromResourceAssembler
{
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(resource.Name);
    }
}