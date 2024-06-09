using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.Publishing.Domain.Services;

public interface iExternalReportQueryService
{
    Task<IEnumerable<ExternalReport>> ListAsync();

}