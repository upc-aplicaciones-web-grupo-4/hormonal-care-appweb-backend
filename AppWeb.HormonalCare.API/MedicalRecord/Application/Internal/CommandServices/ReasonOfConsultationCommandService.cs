using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices;

public class ReasonOfConsultationCommandService(IReasonOfConsultationRepository reasonOfConsultationRepository, IUnitOfWork unitOfWork) : IReasonOfConsultationCommandService
{
    public async Task<ReasonOfConsultation?> Handle(CreateReasonOfConsultationCommand command)
    {
        var reasonOfConsultation = new ReasonOfConsultation(command);
        try
        {
            await reasonOfConsultationRepository.AddAsync(reasonOfConsultation);
            await unitOfWork.CompleteAsync();
            return reasonOfConsultation;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the reason of consultation: {e.Message}");
            return null;
        }
    }
    
    //Caution with this method
    public async Task<ReasonOfConsultation?> Handle(UpdateReasonOfConsultationCommand command)
    {
        var reasonOfConsultation = await reasonOfConsultationRepository.FindByIdAsync(command.Id);
        if (reasonOfConsultation == null)
        {
            throw new ArgumentException($"ReasonOfConsultation with id {command.Id} does not exist");
        }

        try
        {
            reasonOfConsultation.UpdateInformation(command.Description, command.Symptoms);
            reasonOfConsultationRepository.Update(reasonOfConsultation);
            await unitOfWork.CompleteAsync();
            return reasonOfConsultation;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the reason of consultation: {e.Message}");
            return null;
        }
    } 
}