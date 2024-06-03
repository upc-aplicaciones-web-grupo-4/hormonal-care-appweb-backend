using AppWeb.HormonalCare.API.Publishing.Domain.Model.Entities;
using AppWeb.HormonalCare.API.Publishing.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.Publishing.Interfaces.REST.Transform;

public static class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        Console.WriteLine("Category Name is " + entity.Name);
        return new CategoryResource(entity.Id, entity.Name);
    }
}