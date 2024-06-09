using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices
{
    public class MedicationQueryService(IMedicationRepository medicationRepository): IMedicationQueryService 
    {
        public async Task<IEnumerable<Medication>> Handle(GetAllMedicationsQuery query)
        {
            return await medicationRepository.ListAsync();
        }
        
        public async Task<Medication?> Handle(GetMedicationByIdQuery query)
        {
            return await medicationRepository.FindByIdAsync(query.Id);
        }

        public Task<Medication?> Handle(GetMedicationsByMedicationTypeIdQuery query)
        {
            return medicationRepository.FindByMedicationTypeIdAsync(query.MedicationTypeId);
        }

        public async Task<Medication?> Handle(GetMedicationsByPrescriptionIdQuery query)
        {
            return await medicationRepository.FindByPrescriptionIdAsync(query.PrescriptionId);
        }
        
      
    }
}