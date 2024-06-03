using AppWeb.HormonalCare.API.Profiles.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.Profiles.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.FullName, entity.EmailAddress, entity.StreetAddress);
    }
}