using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices
{
    public class MedicationCommandService(
        IMedicationRepository medicationRepository,
        IMedicationTypeRepository medicationTypeRepository,
        IPrescriptionRepository prescriptionRepository,
        IUnitOfWork unitOfWork) : IMedicationCommandService
    {
        
        public async Task<Medication?> Handle(CreateMedicationCommand command)
        {
            try
            {
                var prescription = new Prescription(); 
                var medicationType = new MedicationType(); 

                await prescriptionRepository.AddAsync(prescription);
                await unitOfWork.CompleteAsync();

                await medicationTypeRepository.AddAsync(medicationType);
                await unitOfWork.CompleteAsync();

                var medication = new Medication(command, prescription, medicationType);
                await medicationRepository.AddAsync(medication);
                await unitOfWork.CompleteAsync();

                return medication;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the prescription  : {e.Message}");
                return null;
            }
        }

        public async Task<Medication?> Handle(UpdateMedicationCommand command)
        {
            var medication = await medicationRepository.FindByIdAsync(command.Id);

            if (medication == null)
            {
                throw new ArgumentException("Medication not found");
            }

            var prescription = await prescriptionRepository.FindByIdAsync(command.PrescriptionId);
            var medicationType = await medicationTypeRepository.FindByIdAsync(command.MedicationTypeId);

            if (prescription == null || medicationType == null)
            {
                throw new ArgumentException("Prescription or MedicationType not found");
            }

            medication.Update(command, prescription, medicationType);

            medicationRepository.Update(medication);
            await unitOfWork.CompleteAsync();

            return medication;
        }
    }
}
