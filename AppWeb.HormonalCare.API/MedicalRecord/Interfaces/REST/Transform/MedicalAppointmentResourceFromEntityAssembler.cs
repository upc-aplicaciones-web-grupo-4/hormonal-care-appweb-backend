using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class MedicalAppointmentResourceFromEntityAssembler
{
    public static MedicalAppointmentResource ToResourceFromEntity(MedicalAppointment entity)
    {
        return new MedicalAppointmentResource(
            entity.Id,
            entity.eventDate.eventDate,
            entity.startTime.startTime,
            entity.endTime.endTime,
            entity.tittle,
            entity.description,
            entity.doctorEmail.doctorEmail,
            entity.patientEmail.email
        );
    }
}


