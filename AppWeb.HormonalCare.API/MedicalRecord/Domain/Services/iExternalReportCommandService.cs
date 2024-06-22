using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface iExternalReportCommandService
{
    Task AddAsync(ExternalReport externalReport);
    Task CompleteAsync();
    Task<ServiceResponse<ExternalReport>> CreateExternalReportAsync(ExternalReportResource externalReportResource);
}