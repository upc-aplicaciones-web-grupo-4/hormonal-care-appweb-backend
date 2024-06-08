using AppWeb.HormonalCare.API.Publishing.Domain.Services;
using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;
using AppWeb.HormonalCare.API.StoryClinic.Domain.Repositories;
using AppWeb.HormonalCare.API.StoryClinic.Interfaces.REST.Resources;
using System.Threading.Tasks;

namespace AppWeb.HormonalCare.API.Publishing.Application.Internal.CommandServices;

public class ExternalReportCommandService : iExternalReportCommandService
{
    private readonly IExternalReportRepository _externalReportRepository;

    public ExternalReportCommandService(IExternalReportRepository externalReportRepository)
    {
        _externalReportRepository = externalReportRepository;
    }

    public async Task AddAsync(ExternalReport externalReport)
    {
        await _externalReportRepository.AddAsync(externalReport);
    }

    public async Task CompleteAsync()
    {
        await _externalReportRepository.CompleteAsync();
    }

    public async Task<ServiceResponse<ExternalReport>> CreateExternalReportAsync(ExternalReportResource externalReportResource)
    {
        try
        {
            var externalReport = new ExternalReport
            {
                Description = externalReportResource.Description,
                ReportTypeId = externalReportResource.ReportTypeId
            };

            await AddAsync(externalReport);
            await CompleteAsync();

            return new ServiceResponse<ExternalReport>(externalReport);
        }
        catch (Exception ex)
        {
            return new ServiceResponse<ExternalReport>($"An error occurred when saving the external report: {ex.Message}");
        }
    }
}