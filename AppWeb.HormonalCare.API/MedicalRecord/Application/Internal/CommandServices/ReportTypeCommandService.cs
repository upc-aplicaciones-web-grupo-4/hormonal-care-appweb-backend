using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices
{
    public class ReportTypeCommandService : IReportTypeCommandService
    {
        private readonly IReportTypeRepository _reportTypeRepository;

        public ReportTypeCommandService(IReportTypeRepository reportTypeRepository)
        {
            _reportTypeRepository = reportTypeRepository;
        }

        public async Task AddAsync(ReportType reportType)
        {
            await _reportTypeRepository.AddAsync(reportType);
        }

        public async Task CompleteAsync()
        {
            await _reportTypeRepository.CompleteAsync();
        }

        public async Task UpdateAsync(ReportType reportType)
        {
            _reportTypeRepository.Update(reportType);
        }

        public async Task DeleteAsync(ReportType reportType)
        {
            _reportTypeRepository.Delete(reportType);
        }
    }
}