using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands
{
    public record CreateMedicationCommand(
       int PrescriptionId, int MedicationTypeId,string DrugName, int Quantity, string Concentration, int Frequency, string Duration
    );
}