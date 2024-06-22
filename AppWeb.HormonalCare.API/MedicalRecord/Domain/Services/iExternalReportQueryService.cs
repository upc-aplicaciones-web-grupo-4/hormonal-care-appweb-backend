using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface iExternalReportQueryService
{
    Task<IEnumerable<ExternalReport>> ListAsync();

}