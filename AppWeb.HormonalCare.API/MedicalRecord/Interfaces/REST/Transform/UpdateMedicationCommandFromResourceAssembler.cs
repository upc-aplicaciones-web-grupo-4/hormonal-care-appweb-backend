using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class UpdateMedicationCommandFromResourceAssembler
{
    public static UpdateMedicationCommand ToCommandFromResource(int id, UpdateMedicationResource resource)
    {
        return new UpdateMedicationCommand(id, resource.PrescriptionId, resource.MedicationTypeId, resource.DrugName, resource.Quantity, resource.Concentration, resource.Frequency,resource.Duration);
    }
}