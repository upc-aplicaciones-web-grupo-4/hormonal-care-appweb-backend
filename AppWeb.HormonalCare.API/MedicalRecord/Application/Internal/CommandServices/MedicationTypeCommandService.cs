
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices
{
    public class MedicationTypeCommandService : IMedicationTypeCommandService
    {
        private readonly IMedicationTypeRepository _medicationTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MedicationTypeCommandService(IMedicationTypeRepository medicationTypeRepository, IUnitOfWork unitOfWork)
        {
            _medicationTypeRepository = medicationTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MedicationType?> Handle(CreateMedicationTypeCommand command)
        {
            var medicationType = new MedicationType(command);

            await _medicationTypeRepository.AddAsync(medicationType);
            await _unitOfWork.CompleteAsync();

            return medicationType;
        }

        public async Task<MedicationType?> Handle(UpdateMedicationTypeCommand command)
        {
            var medicationType = await _medicationTypeRepository.FindByIdAsync(command.Id);

            if (medicationType == null)
            {
                throw new ArgumentException("MedicationType not found");
            }

            medicationType.Update(command);

            _medicationTypeRepository.Update(medicationType);
            await _unitOfWork.CompleteAsync();

            return medicationType;
        }
    }
}