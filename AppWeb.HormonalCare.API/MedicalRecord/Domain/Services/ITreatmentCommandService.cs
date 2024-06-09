using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface ITreatmentCommandService
{
    Task<Treatment?> Handle(CreateTreatmentCommand command);
    Task<Treatment?> Handle(UpdateTreatmentCommand command);
}