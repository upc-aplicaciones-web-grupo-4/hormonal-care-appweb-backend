using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public static class CreateMedicationTypeCommandFromResourceAssembler
{
    public static CreateMedicationTypeCommand ToCommandFromResource(CreateMedicationTypeResource resource)
    {
        return new CreateMedicationTypeCommand(resource.MedicationTypeName);
    }
}