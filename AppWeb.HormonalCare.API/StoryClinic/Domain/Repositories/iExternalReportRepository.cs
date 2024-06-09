using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.StoryClinic.Domain.Repositories;

public interface IExternalReportRepository
{
    Task AddAsync(ExternalReport externalReport);
    Task CompleteAsync();
    Task<IEnumerable<ExternalReport>> ListAsync();

}