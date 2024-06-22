using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;

public interface IExternalReportRepository
{
    Task AddAsync(ExternalReport externalReport);
    Task CompleteAsync();
    Task<IEnumerable<ExternalReport>> ListAsync();

}