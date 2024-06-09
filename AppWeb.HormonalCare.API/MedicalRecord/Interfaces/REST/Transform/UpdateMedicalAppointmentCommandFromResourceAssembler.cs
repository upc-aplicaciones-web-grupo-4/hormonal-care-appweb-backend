using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class UpdateMedicalAppointmentCommandFromResourceAssembler
{
    public static UpdateMedicalAppointmentCommand ToCommandFromResource(
        int id, UpdateMedicalAppointmentResource resource)
    {
        return new UpdateMedicalAppointmentCommand(
            id,
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