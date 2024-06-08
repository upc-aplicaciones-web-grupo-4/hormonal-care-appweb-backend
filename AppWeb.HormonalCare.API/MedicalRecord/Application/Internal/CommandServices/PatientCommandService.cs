using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices;

public class PatientCommandService(
    IPatientRepository patientRepository, IUnitOfWork unitOfWork) : IPatientCommandService
{
    public async Task<Patient?> Handle(CreatePatientCommand command)
    {
        var patient = new Patient(command);
        try
        {
            await patientRepository.AddAsync(patient);
            await unitOfWork.CompleteAsync();
            return patient;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the patient: {e.Message}");
            return null;
        }
    }

    public async Task<Patient?> Handle(UpdatePatientCommand command)
    {
        var patient = await patientRepository.FindByIdAsync(command.Id);
        if (patient == null)
        {
            throw new ArgumentException($"Patient with id {command.Id} does not exist");
        }

        patient.Update(command);
        try
        {
            await unitOfWork.CompleteAsync();
            return patient;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the MedicalExam: {e.Message}");
            return null;
        }

    }
}

