using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class UpdateDoctorAppointmentFeeCommandFromResourceAssembler
{
    public static UpdateDoctorAppointmentFeeCommand ToCommandFromResource(int id, UpdateDoctorAppointmentFeeRecourse resource)
    {
        return new UpdateDoctorAppointmentFeeCommand(id, resource.appointmentFee);
    }
}