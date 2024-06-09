using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.StoryClinic.Domain.Repositories;

public interface IReportTypeRepository
{
    Task<ReportType> GetByIdAsync(int id);
    Task<IEnumerable<ReportType>> GetAllAsync();
    Task AddAsync(ReportType entity);
    void Update(ReportType entity);
    void Delete(ReportType entity);
}