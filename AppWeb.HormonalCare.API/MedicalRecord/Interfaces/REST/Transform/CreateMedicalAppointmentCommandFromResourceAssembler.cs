using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class CreateMedicalAppointmentCommandFromResourceAssembler
{
    public static CreateMedicalAppointmentCommand ToCommandFromResource(CreateMedicalAppointmentResource resource)
    {
        return new CreateMedicalAppointmentCommand(
            resource.eventDate,
            resource.startTime,
            resource.endTime,
            resource.tittle,
            resource.description,
            resource.doctorEmail,
            resource.patientEmail
        );
    }
}