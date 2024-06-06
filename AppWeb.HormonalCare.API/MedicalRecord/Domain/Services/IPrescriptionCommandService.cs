using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services
{
    public interface IPrescriptionCommandService
    {
        Task<Prescription?> Handle(CreatePrescriptionCommand command);
        Task<Prescription?> Handle(UpdatePrescriptionCommand command);
    }
}