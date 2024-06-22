﻿using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories
{
    public class ExternalReportRepository : IExternalReportRepository
    {
        private readonly AppDbContext _context;

        public ExternalReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExternalReport>> ListAsync()
        {
            return await _context.ExternalReports
                .ToListAsync();
        }

        public async Task AddAsync(ExternalReport externalReport)
        {
            await _context.ExternalReports.AddAsync(externalReport);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}