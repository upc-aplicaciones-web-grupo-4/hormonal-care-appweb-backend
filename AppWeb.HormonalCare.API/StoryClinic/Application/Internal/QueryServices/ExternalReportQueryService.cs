using AppWeb.HormonalCare.API.Publishing.Domain.Services;
using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;
using AppWeb.HormonalCare.API.StoryClinic.Domain.Repositories;

namespace AppWeb.HormonalCare.API.Publishing.Application.Internal.QueryServices;

public class ExternalReportQueryService : iExternalReportQueryService
{
    private readonly IExternalReportRepository _externalReportRepository;

    public ExternalReportQueryService(IExternalReportRepository externalReportRepository)
    {
        _externalReportRepository = externalReportRepository;
    }

    public async Task<IEnumerable<ExternalReport>> ListAsync()
    {
        return await _externalReportRepository.ListAsync();
    }

    public async Task<ServiceResponse<IEnumerable<ExternalReport>>> GetAllExternalReportsAsync()
    {
        try
        {
            var externalReports = await _externalReportRepository.ListAsync();
            return new ServiceResponse<IEnumerable<ExternalReport>>(externalReports);
        }
        catch (Exception ex)
        {
            return new ServiceResponse<IEnumerable<ExternalReport>>($"An error occurred when retrieving external reports: {ex.Message}");
        }
    }
}