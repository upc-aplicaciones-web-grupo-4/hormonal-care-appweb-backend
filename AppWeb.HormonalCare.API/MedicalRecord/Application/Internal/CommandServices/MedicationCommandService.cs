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
                    var prescription = await prescriptionRepository.FindByIdAsync(command.PrescriptionId);
                    if (prescription == null)
                    {
                        throw new Exception("Prescription not found");
                    }

                    var medicationType = await medicationTypeRepository.FindByIdAsync(command.MedicationTypeId);
                    if (medicationType == null)
                    {
                        throw new Exception("MedicationType not found");
                    }

                    var medication = new Medication(command, prescription, medicationType);
                    try
                    {
                        await medicationRepository.AddAsync(medication);
                        await unitOfWork.CompleteAsync();
                        return medication;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"An error occurred while creating the Medication: {e.Message}");
                        return null;
                    }
        }

        public async Task<Medication?> Handle(UpdateMedicationCommand command)
        {
            var medication = await medicationRepository.FindByIdAsync(command.Id);
            if (medication == null)
            {
                throw new Exception("Medication not found");
            }

            var prescription = await prescriptionRepository.FindByIdAsync(command.PrescriptionId);
            if (prescription == null)
            {
                throw new Exception("Prescription not found");
            }

            var medicationType = await medicationTypeRepository.FindByIdAsync(command.MedicationTypeId);
            if (medicationType == null)
            {
                throw new Exception("MedicationType not found");
            }

            medication.Update(command, prescription, medicationType);

            try
            {
                await unitOfWork.CompleteAsync();
                return medication;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while updating the Medication: {e.Message}");
                return null;
            }
        }
    }
}
