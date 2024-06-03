namespace AppWeb.HormonalCare.API.Publishing.Domain.Model.Commands;

public record CreateTutorialCommand(string Title, string Summary, int CategoryId);