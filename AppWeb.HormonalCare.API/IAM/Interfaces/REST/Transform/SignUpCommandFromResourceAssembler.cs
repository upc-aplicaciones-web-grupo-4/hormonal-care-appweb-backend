using AppWeb.HormonalCare.API.IAM.Domain.Model.Commands;
using AppWeb.HormonalCare.API.IAM.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}