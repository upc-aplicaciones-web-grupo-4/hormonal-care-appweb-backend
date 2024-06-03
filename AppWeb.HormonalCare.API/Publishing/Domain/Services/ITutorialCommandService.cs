using AppWeb.HormonalCare.API.Publishing.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.Publishing.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.Publishing.Domain.Services;

public interface ITutorialCommandService
{
    Task<Tutorial?> Handle(AddVideoAssetToTutorialCommand command);
    Task<Tutorial?> Handle(CreateTutorialCommand command);
}