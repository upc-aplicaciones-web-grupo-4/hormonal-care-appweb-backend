using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services
{
    public interface IReportTypeQueryService
    {
        Task<ReportType> GetByIdAsync(int id);
        
        Task<IEnumerable<ReportType>> ListAsync();
        Task<IEnumerable<ReportType>> GetAllAsync();
    }
}