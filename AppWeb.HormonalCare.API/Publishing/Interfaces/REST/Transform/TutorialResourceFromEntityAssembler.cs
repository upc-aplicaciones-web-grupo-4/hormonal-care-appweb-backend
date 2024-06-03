using AppWeb.HormonalCare.API.Publishing.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.Publishing.Interfaces.REST.Resources;
using Microsoft.OpenApi.Extensions;

namespace AppWeb.HormonalCare.API.Publishing.Interfaces.REST.Transform;

public static class TutorialResourceFromEntityAssembler
{
    public static TutorialResource ToResourceFromEntity(Tutorial tutorial)
    {
        return new TutorialResource(
            tutorial.Id,
            tutorial.Title,
            tutorial.Summary,
            CategoryResourceFromEntityAssembler.ToResourceFromEntity(tutorial.Category),
            tutorial.Status.GetDisplayName());
    }
}