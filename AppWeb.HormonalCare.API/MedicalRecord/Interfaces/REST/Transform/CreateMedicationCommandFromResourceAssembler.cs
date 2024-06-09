using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public static class CreateMedicationCommandFromResourceAssembler
{
    public static CreateMedicationCommand ToCommandFromResource(CreateMedicationResource resource)
    {
        return new CreateMedicationCommand(
            resource.PrescriptionId, resource.MedicationTypeId,resource.DrugName, 
            resource.Quantity, resource.Concentration, resource.Frequency, resource.Duration);
    }
}
