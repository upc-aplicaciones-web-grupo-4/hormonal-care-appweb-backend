using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services
{
    public interface IMedicationCommandService
    {
        Task<Medication?> Handle(CreateMedicationCommand command);
        Task<Medication?> Handle(UpdateMedicationCommand command);
    }
}