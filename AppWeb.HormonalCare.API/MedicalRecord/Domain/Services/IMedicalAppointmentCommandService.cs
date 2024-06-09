using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface IMedicalAppointmentCommandService
{
    Task<MedicalAppointment?> Handle(CreateMedicalAppointmentCommand command);
    Task<MedicalAppointment?> Handle(UpdateMedicalAppointmentCommand command);
}



