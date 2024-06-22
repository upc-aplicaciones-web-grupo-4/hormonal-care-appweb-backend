using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories
{
    public interface IReportTypeRepository
    {
        Task<ReportType> GetByIdAsync(int id);
        Task<IEnumerable<ReportType>> GetAllAsync();
        Task AddAsync(ReportType entity);
        
        Task CompleteAsync();
        void Update(ReportType entity);
        void Delete(ReportType entity);
    }
}