using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices
{
    public class MedicationTypeCommandService(IMedicationTypeRepository medicationTypeRepository, IUnitOfWork unitOfWork): IMedicationTypeCommandService
    {
    
        public async Task<MedicationType?> Handle(CreateMedicationTypeCommand command)
        {
            var medicationType = new MedicationType(command);

            await medicationTypeRepository.AddAsync(medicationType);
            await unitOfWork.CompleteAsync();

            return medicationType;
        }

        public async Task<MedicationType?> Handle(UpdateMedicationTypeCommand command)
        {
            var medicationType = await medicationTypeRepository.FindByIdAsync(command.Id);

            if (medicationType == null)
            {
                throw new ArgumentException("MedicationType not found");
            }

            medicationType.Update(command.TypeName);

            medicationTypeRepository.Update(medicationType);
            await unitOfWork.CompleteAsync();
            return medicationType;
        }
    }
}