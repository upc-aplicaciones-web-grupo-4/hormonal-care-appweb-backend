using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface IPatientCommandService
{
    Task<Patient?> Handle(CreatePatientCommand command);
    Task<Patient?> Handle(UpdatePatientCommand command);
}