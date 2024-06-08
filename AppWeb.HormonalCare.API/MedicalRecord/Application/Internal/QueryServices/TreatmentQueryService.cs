using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices;

public class TreatmentQueryService (ITreatmentRepository treatementRepository) : ITreatmentQueryService
{
    public async Task<Treatment?> Handle(GetTreatmentByIdQuery query)
    {
        //Caution with this 
        //Caution with this 
        //Caution with this 
        //Caution with this 

        return await treatementRepository.FindByIdAsync(query.Id);
    }
}

