using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices;

public class TreatmentQueryService (ITreatmentRepository treatementRepository) : ITreatmentQueryService
{
    public async Task<IEnumerable<Treatment>> Handle(GetAllTreatmentsQuery query)
    {
        return await treatementRepository.ListAsync();
    }

    public async Task<Treatment?> Handle(GetTreatmentByIdQuery query)
    {
        return await treatementRepository.FindByIdAsync(query.Id);
    }
}

