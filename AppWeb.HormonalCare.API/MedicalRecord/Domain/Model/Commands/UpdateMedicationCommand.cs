namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands
{
    public record UpdateMedicationCommand(
        int Id, 
        int PrescriptionId, int MedicationTypeId, string DrugName, int Quantity, string Concentration, int Frequency, string Duration
    );
}