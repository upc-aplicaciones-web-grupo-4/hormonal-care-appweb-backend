using AppWeb.HormonalCare.API.Publishing.Domain.Services;
using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;
using AppWeb.HormonalCare.API.StoryClinic.Domain.Repositories;

namespace AppWeb.HormonalCare.API.Publishing.Application.Internal.QueryServices;

public class DiagnosticQueryService : IDiagnosticQueryService
{
    private readonly IDiagnosticRepository _diagnosticRepository;

    public DiagnosticQueryService(IDiagnosticRepository diagnosticRepository)
    {
        _diagnosticRepository = diagnosticRepository;
    }

    public async Task<IEnumerable<Diagnostic>> GetAllDiagnosticsAsync()
    {
        return await _diagnosticRepository.GetAllDiagnosticsAsync();
    }
}