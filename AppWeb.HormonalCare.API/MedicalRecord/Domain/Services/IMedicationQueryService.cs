using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services
{
    public interface IMedicationQueryService
    {
        
        Task<Medication?> Handle(GetMedicationByIdQuery query);
        Task<Medication?> Handle(GetMedicationsByMedicationTypeIdQuery query);
        Task<Medication?> Handle(GetMedicationsByPrescriptionIdQuery query);
        Task<IEnumerable<Medication>> Handle(GetAllMedicationsQuery query);
    }
}