using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface ITreatmentQueryService
{
    Task<IEnumerable<Treatment>> Handle(GetAllTreatmentsQuery query);
    Task<Treatment?> Handle(GetTreatmentByIdQuery query);
}