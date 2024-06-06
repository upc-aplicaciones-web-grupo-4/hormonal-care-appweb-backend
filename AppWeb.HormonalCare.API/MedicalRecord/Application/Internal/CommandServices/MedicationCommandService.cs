using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices
{
    public class MedicationCommandService : IMedicationCommandService
    {
        private readonly IMedicationRepository _medicationRepository;
        private readonly IMedicationTypeRepository _medicationTypeRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MedicationCommandService(IMedicationRepository medicationRepository, IMedicationTypeRepository medicationTypeRepository, IPrescriptionRepository prescriptionRepository, IUnitOfWork unitOfWork)
        {
            _medicationRepository = medicationRepository;
            _medicationTypeRepository = medicationTypeRepository;
            _prescriptionRepository = prescriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Medication?> Handle(CreateMedicationCommand command)
        {
            var prescription = await _prescriptionRepository.FindByIdAsync(command.prescriptionId);
            var medicationType = await _medicationTypeRepository.FindByIdAsync(command.medicationTypeId);

            if (prescription == null || medicationType == null)
            {
                throw new ArgumentException("Prescription or MedicationType not found");
            }

            var medication = new Medication(command, prescription, medicationType);

            await _medicationRepository.AddAsync(medication);
            await _unitOfWork.CompleteAsync();

            return medication;
        }

        public async Task<Medication?> Handle(UpdateMedicationCommand command)
        {
            var medication = await _medicationRepository.FindByIdAsync(command.Id);

            if (medication == null)
            {
                throw new ArgumentException("Medication not found");
            }

            var prescription = await _prescriptionRepository.FindByIdAsync(command.prescriptionId);
            var medicationType = await _medicationTypeRepository.FindByIdAsync(command.medicationTypeId);

            if (prescription == null || medicationType == null)
            {
                throw new ArgumentException("Prescription or MedicationType not found");
            }

            medication.Update(command, prescription, medicationType);

            _medicationRepository.Update(medication);
            await _unitOfWork.CompleteAsync();

            return medication;
        }
    }
}