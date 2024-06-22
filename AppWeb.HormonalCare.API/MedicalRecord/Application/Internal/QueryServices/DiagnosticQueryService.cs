using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices;

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