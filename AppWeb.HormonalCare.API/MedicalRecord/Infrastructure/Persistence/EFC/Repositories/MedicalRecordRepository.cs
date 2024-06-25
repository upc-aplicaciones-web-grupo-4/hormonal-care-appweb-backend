using AppWeb.HormonalCare.API.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories;

public class MedicalRecordRepository (AppDbContext context) : BaseRepository<Domain.Model.Aggregates.MedicalRecord>(context), IMedicalRecordRepository
{
    public new async Task<Domain.Model.Aggregates.MedicalRecord?> FindByIdAsync(int id) =>
        await Context.Set<Domain.Model.Aggregates.MedicalRecord>()
            .Include(t => t.Patient)
            .Where(t => t.Id == id).FirstOrDefaultAsync();
}