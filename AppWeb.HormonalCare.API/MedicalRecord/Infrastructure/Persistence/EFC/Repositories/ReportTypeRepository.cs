using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories
{
    public class ReportTypeRepository : IReportTypeRepository
    {
        private readonly AppDbContext _context;

        public ReportTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ReportType> GetByIdAsync(int id)
        {
            return await _context.Set<ReportType>().FindAsync(id);
        }

        public async Task<IEnumerable<ReportType>> GetAllAsync()
        {
            return await _context.Set<ReportType>().ToListAsync();
        }

        public async Task AddAsync(ReportType entity)
        {
            await _context.Set<ReportType>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(ReportType entity)
        {
            _context.Set<ReportType>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(ReportType entity)
        {
            _context.Set<ReportType>().Remove(entity);
            _context.SaveChanges();
        }
    }
}