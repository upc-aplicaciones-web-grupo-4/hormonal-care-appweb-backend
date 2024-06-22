using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices;

public class DiagnosticCommandService : iDiagnosticCommandService
{
    private readonly IDiagnosticRepository _diagnosticRepository;

    public DiagnosticCommandService(IDiagnosticRepository diagnosticRepository)
    {
        _diagnosticRepository = diagnosticRepository;
    }

    public async Task<ServiceResponse<Diagnostic>> CreateDiagnosticAsync(Diagnostic diagnostic)
    {
        try
        {
            await _diagnosticRepository.CreateDiagnosticAsync(diagnostic);
            return new ServiceResponse<Diagnostic>(diagnostic);
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Diagnostic>(ex.Message);
        }
    }
}