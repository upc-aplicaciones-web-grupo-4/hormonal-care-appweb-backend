using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class CreatePatientCommandFromResourceAssembler
{
    public static CreatePatientCommand ToCommandFromResource(CreatePatientResource resource)
    {
        return new CreatePatientCommand(
            resource.FirstName,
            resource.LastName,
            resource.Image,
            resource.Gender,
            resource.BirthDate,
            resource.Phone,
            resource.Email,
            resource.TypeofBloodName);
    }
}
