using AppWeb.HormonalCare.API.IAM.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.IAM.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}