using AppWeb.HormonalCare.API.Profiles.Domain.Model.ValueObjects;

namespace AppWeb.HormonalCare.API.Profiles.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);