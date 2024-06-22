using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;

public interface IDiagnosticRepository
{
    Task<IEnumerable<Diagnostic>> GetAllDiagnosticsAsync();
    Task<Diagnostic> CreateDiagnosticAsync(Diagnostic diagnostic);
}