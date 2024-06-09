using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.Publishing.Domain.Services;

public interface IDiagnosticQueryService
{
    Task<IEnumerable<Diagnostic>> GetAllDiagnosticsAsync();
}
