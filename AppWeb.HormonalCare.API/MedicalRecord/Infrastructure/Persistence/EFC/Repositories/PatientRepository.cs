using AppWeb.HormonalCare.API.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories;

public class PatientRepository(AppDbContext context) : BaseRepository<Patient>(context), IPatientRepository
{

    public new async Task<Patient?> FindByIdAsync(int id) =>
        await Context.Set<Patient>()
            .Include(t => t.Profile)
            .Where(t => t.Id == id).FirstOrDefaultAsync();
    
    public new async Task<IEnumerable<Patient>> ListAsync()
    {
        return await Context.Set<Patient>()
            .Include(t => t.Profile)
            .ToListAsync();
    }

    
    public Task<Patient?> FindByProfileIdAsync(int profileId)
    {
        return Context.Set<Patient>()
            .Include(patient => patient.Profile)
            .Where(p => p.ProfileId == profileId).FirstOrDefaultAsync();
    }
    
    public Task<Patient?> FindByPatientRecordIdAsync(PatientRecord patientRecordId)
    {
        return Context.Set<Patient>()
            .Include(patient => patient.Profile)
            .Where(p => p.PatientRecordId == patientRecordId).FirstOrDefaultAsync();
    }
    
    
    
}