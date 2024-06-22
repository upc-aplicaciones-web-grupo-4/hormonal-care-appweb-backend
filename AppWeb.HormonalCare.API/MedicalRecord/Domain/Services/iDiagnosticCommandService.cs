using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface iDiagnosticCommandService
{
    Task<ServiceResponse<Diagnostic>> CreateDiagnosticAsync(Diagnostic diagnostic);
}