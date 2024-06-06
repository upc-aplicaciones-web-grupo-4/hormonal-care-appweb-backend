using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices
{
    public class PrescriptionCommandService : IPrescriptionCommandService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PrescriptionCommandService(IPrescriptionRepository prescriptionRepository, IUnitOfWork unitOfWork)
        {
            _prescriptionRepository = prescriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Prescription?> Handle(CreatePrescriptionCommand command)
        {
            var prescription = new Prescription(command);

            await _prescriptionRepository.AddAsync(prescription);
            await _unitOfWork.CompleteAsync();

            return prescription;
        }

        public async Task<Prescription?> Handle(UpdatePrescriptionCommand command)
        {
            var prescription = await _prescriptionRepository.FindByIdAsync(command.Id);

            if (prescription == null)
            {
                throw new ArgumentException("Prescription not found");
            }

            prescription.Update(command);

            _prescriptionRepository.Update(prescription);
            await _unitOfWork.CompleteAsync();

            return prescription;
        }
    }
}