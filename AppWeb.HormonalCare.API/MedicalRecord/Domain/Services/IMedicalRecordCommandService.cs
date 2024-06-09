using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface IMedicalRecordCommandService
{
    Task<Model.Aggregates.MedicalRecord?> Handle(CreateMedicalRecordCommand command);
}