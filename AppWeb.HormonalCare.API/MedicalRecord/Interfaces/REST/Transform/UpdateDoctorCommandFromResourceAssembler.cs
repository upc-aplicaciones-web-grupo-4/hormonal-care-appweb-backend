using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class UpdateDoctorCommandFromResourceAssembler
{
    public static UpdateDoctorCommand ToCommandFromResource(int id, UpdateDoctorRecourse resource)
    {
        return new UpdateDoctorCommand(id, 
            resource.FirstName,
            resource.LastName,
            resource.Image,
            resource.Gender,
            resource.BirthDate,
            resource.Phone,
            resource.Email,
            resource.appointmentFee,
            resource.subscriptionId
            );
    }
}