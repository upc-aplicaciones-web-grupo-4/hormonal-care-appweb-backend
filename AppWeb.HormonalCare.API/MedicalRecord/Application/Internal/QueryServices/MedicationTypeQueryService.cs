using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices;

public class MedicationTypeQueryService (IMedicationTypeRepository medicationTypeRepository) : IMedicationTypeQueryService

{
    public async Task<MedicationType?> Handle(GetMedicationTypeByIdQuery query)
    {
        return await medicationTypeRepository.FindByIdAsync(query.Id);
    }
}
