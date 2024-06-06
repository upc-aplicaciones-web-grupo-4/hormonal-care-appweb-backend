using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;


namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices
{
    public class PrescriptionQueryService(IPrescriptionRepository prescriptionRepository) : IPrescriptionQueryService
    {
        public async Task<Prescription?> Handle(GetPrescriptionByIdQuery query)
        {
            return await prescriptionRepository.FindByIdAsync(query.prescriptionId);
        }
        
    }
}