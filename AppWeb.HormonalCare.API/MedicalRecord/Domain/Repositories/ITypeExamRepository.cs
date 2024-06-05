using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;
using System.Threading.Tasks;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;

public interface ITypeExamRepository : IBaseRepository<TypeExam>
{
    Task<TypeExam?> FindTypeExamByNameAsync(TypeExamName name);
}