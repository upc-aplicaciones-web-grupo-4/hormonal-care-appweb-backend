using AppWeb.HormonalCare.API.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories;

public class MedicalRecordRepository (AppDbContext context) : BaseRepository<Domain.Model.Aggregates.MedicalRecord>(context), IMedicalRecordRepository
{
    
}