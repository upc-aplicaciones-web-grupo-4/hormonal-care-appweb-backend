using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;
using AppWeb.HormonalCare.API.StoryClinic.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.Publishing.Domain.Services;

public interface iExternalReportCommandService
{
    Task AddAsync(ExternalReport externalReport);
    Task CompleteAsync();
    Task<ServiceResponse<ExternalReport>> CreateExternalReportAsync(ExternalReportResource externalReportResource);
}