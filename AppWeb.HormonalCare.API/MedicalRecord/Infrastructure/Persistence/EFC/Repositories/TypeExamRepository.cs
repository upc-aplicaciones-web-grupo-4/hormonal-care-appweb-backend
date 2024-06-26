using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;
using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories;

public class TypeExamRepository(AppDbContext context) : BaseRepository<TypeExam>(context), ITypeExamRepository
{
    public Task<TypeExam?> FindTypeExamByNameAsync(TypeExamName name)
    {
        return Context.Set<TypeExam>().Where(t => t.Name == name).FirstOrDefaultAsync();
    }
}