using AppWeb.HormonalCare.API.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories
{
    public class MedicationRepository (AppDbContext context) : BaseRepository<Medication>(context), IMedicationRepository
    {
        public async Task<Medication?> FindByPrescriptionIdAsync(int prescriptionId)
        {
            return await Context.Set<Medication>()
                .Where(m => m.PrescriptionId == prescriptionId)
                .FirstOrDefaultAsync();
        }

        public async Task<Medication?> FindByMedicationTypeIdAsync(int typeId)
        {
            return await Context.Set<Medication>()
                .Where(m => m.MedicationTypeId == typeId)
                .FirstOrDefaultAsync();
        }
    }
}