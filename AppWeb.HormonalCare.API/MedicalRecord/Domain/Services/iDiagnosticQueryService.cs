using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface IDiagnosticQueryService
{
    Task<IEnumerable<Diagnostic>> GetAllDiagnosticsAsync();
}
