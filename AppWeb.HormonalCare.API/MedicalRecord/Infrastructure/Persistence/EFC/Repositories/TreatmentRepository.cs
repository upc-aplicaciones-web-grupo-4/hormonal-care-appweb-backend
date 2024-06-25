using AppWeb.HormonalCare.API.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories;

public class TreatmentRepository (AppDbContext context) : BaseRepository<Treatment>(context), ITreatmentRepository
{
    public new async Task<Treatment?> FindByIdAsync(int id) =>
        await Context.Set<Treatment>().Include(t => t.MedicalRecord)
            .Where(t => t.Id == id).FirstOrDefaultAsync();
}

