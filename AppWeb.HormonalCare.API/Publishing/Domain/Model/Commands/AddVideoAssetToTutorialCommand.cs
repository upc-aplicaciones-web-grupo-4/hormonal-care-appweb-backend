namespace AppWeb.HormonalCare.API.Publishing.Domain.Model.Commands;

public record AddVideoAssetToTutorialCommand(string VideoUrl, int TutorialId);