using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services
{
    public interface IMedicationTypeCommandService
    {
        Task<MedicationType?> Handle(CreateMedicationTypeCommand command);
        Task<MedicationType?> Handle(UpdateMedicationTypeCommand command);
    }
}