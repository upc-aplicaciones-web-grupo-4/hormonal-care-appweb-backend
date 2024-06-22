using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services
{
    public interface IReportTypeCommandService
    {
        Task AddAsync(ReportType reportType);
        Task CompleteAsync();
        Task UpdateAsync(ReportType reportType);
        Task DeleteAsync(ReportType reportType);
    }
}