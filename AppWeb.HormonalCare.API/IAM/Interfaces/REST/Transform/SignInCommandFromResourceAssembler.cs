using AppWeb.HormonalCare.API.IAM.Domain.Model.Commands;
using AppWeb.HormonalCare.API.IAM.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}