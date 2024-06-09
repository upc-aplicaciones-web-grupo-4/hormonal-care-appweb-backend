using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;
using AppWeb.HormonalCare.API.StoryClinic.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.Publishing.Domain.Services;

public interface iDiagnosticCommandService
{
    Task<ServiceResponse<Diagnostic>> CreateDiagnosticAsync(DiagnosticResource diagnosticResource);
}