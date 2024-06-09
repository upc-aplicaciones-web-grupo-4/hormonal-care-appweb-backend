using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices
{
    public class PrescriptionCommandService(IPrescriptionRepository prescriptionRepository, IUnitOfWork unitOfWork): IPrescriptionCommandService
    {
        public async Task<Prescription?> Handle(CreatePrescriptionCommand command)
        {
            var prescription = new Prescription(command);

            await prescriptionRepository.AddAsync(prescription);
            await unitOfWork.CompleteAsync();

            return prescription;
        }

        public async Task<Prescription?> Handle(UpdatePrescriptionCommand command)
        {
            var prescription = await prescriptionRepository.FindByIdAsync(command.Id);

            if (prescription == null)
            {
                throw new ArgumentException("Prescription not found");
            }

            prescription.Update(command.DoctorId, command.PatientId, command.PrescriptionDate, command.Notes);

            prescriptionRepository.Update(prescription);
            await unitOfWork.CompleteAsync();

            return prescription;
        }
    }
}