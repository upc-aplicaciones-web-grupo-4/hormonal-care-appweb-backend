using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices
{
    public class ReportTypeQueryService : IReportTypeQueryService
    {
        private readonly IReportTypeRepository _reportTypeRepository;

        public ReportTypeQueryService(IReportTypeRepository reportTypeRepository)
        {
            _reportTypeRepository = reportTypeRepository;
        }

        public async Task<ReportType> GetByIdAsync(int id)
        {
            return await _reportTypeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ReportType>> GetAllAsync()
        {
            return await _reportTypeRepository.GetAllAsync();
        }

        public async Task<IEnumerable<ReportType>> ListAsync()
        {
            return await _reportTypeRepository.GetAllAsync();
        }
    }
}