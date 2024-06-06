using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices;

public class ReasonOfConsultationQueryService (IReasonOfConsultationRepository reasonOfConsultationRepository) : IReasonOfConsultationQueryService
{
    public async Task<ReasonOfConsultation?> Handle(GetReasonOfConsultationByIdQuery query)
    {
        //Caution with this 
        return await reasonOfConsultationRepository.FindByIdAsync(query.Id);
    }
}

