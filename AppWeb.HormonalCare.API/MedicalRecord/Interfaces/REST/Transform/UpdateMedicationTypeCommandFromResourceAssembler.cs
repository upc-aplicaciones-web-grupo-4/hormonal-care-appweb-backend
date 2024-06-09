using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class UpdateMedicationTypeCommandFromResourceAssembler
{
    public static UpdateMedicationTypeCommand ToCommandFromResource(int id, UpdateMedicationTypeResource resource)
    {
        return new UpdateMedicationTypeCommand(id, resource.MedicationTypeName);
    }

}