using AppWeb.HormonalCare.API.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories;

public class ReasonOfConsultationRepository (AppDbContext context) : BaseRepository<ReasonOfConsultation>(context), IReasonOfConsultationRepository
{
    public new async Task<ReasonOfConsultation?> FindByIdAsync(int id) =>
        await Context.Set<ReasonOfConsultation>().Include(t => t.MedicalRecord)
            .Where(t => t.Id == id).FirstOrDefaultAsync();
}
