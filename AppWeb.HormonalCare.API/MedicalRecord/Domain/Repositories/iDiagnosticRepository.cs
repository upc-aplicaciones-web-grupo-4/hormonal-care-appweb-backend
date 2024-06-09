using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.StoryClinic.Domain.Repositories;

public interface IDiagnosticRepository
{
    Task<IEnumerable<Diagnostic>> GetAllDiagnosticsAsync();
    Task<Diagnostic> CreateDiagnosticAsync(Diagnostic diagnostic);
}