using AppWeb.HormonalCare.API.IAM.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.IAM.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}