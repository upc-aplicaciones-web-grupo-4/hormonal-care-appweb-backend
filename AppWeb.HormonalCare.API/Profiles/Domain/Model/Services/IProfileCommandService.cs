using AppWeb.HormonalCare.API.Profiles.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.Profiles.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.Profiles.Domain.Model.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}