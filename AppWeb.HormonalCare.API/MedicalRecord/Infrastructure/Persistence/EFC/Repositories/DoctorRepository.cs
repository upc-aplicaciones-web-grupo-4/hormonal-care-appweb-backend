using AppWeb.HormonalCare.API.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories;

public class DoctorRepository(AppDbContext context) : BaseRepository<Doctor>(context), IDoctorRepository
{
    public new async Task<Doctor?> FindByIdAsync(int id) =>
        await Context.Set<Doctor>()
            .Include(t => t.profile)
            .Where(t => t.Id == id).FirstOrDefaultAsync();

    public new async Task<IEnumerable<Doctor>> ListAsync()
    {
        return await Context.Set<Doctor>()
            .Include(t => t.profile)
            .ToListAsync();
    }

    public Task<Doctor?> FindByProfileIdAsync(int profileId)
    {
        return Context.Set<Doctor>()
            .Include(doctor => doctor.profile)
            .Where(d => d.profileId == profileId).FirstOrDefaultAsync();
    }
}