using AppWeb.HormonalCare.API.Publishing.Domain.Model.Commands;
using AppWeb.HormonalCare.API.Publishing.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.Publishing.Interfaces.REST.Transform;

public static class AddVideoAssetToTutorialCommandFromResourceAssembler
{
    public static AddVideoAssetToTutorialCommand ToCommandFromResource(AddVideoAssetToTutorialResource addVideoAssetToTutorialResource, int tutorialId)
    {
        return new AddVideoAssetToTutorialCommand(addVideoAssetToTutorialResource.VideoUrl, tutorialId);
    }
}