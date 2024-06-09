using AppWeb.HormonalCare.API.Publishing.Domain.Services;
using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;
using AppWeb.HormonalCare.API.StoryClinic.Domain.Repositories;
using AppWeb.HormonalCare.API.StoryClinic.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.Publishing.Application.Internal.CommandServices;

public class DiagnosticCommandService : iDiagnosticCommandService
{
    private readonly IDiagnosticRepository _diagnosticRepository;

    public DiagnosticCommandService(IDiagnosticRepository diagnosticRepository)
    {
        _diagnosticRepository = diagnosticRepository;
    }

    public async Task<ServiceResponse<Diagnostic>> CreateDiagnosticAsync(DiagnosticResource diagnosticResource)
    {
        var diagnostic = new Diagnostic
        {
            Descripcion = diagnosticResource.Descripcion
        };

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