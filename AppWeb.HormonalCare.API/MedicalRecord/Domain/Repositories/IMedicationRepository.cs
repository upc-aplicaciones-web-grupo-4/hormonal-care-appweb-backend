using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;

public interface IMedicationRepository: IBaseRepository<Medication>
{
    Task<Medication?> FindByPrescriptionIdAsync(int prescriptionId);
    Task<Medication?> FindByMedicationTypeIdAsync(int typeId);
}