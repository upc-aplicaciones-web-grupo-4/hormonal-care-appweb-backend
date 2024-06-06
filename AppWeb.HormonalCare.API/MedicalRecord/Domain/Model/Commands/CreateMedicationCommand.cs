namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands
{
    public record CreateMedicationCommand(
        int prescriptionId, int medicalTypeId, string drugName, int quantity, string concentration, int frequency, string duration
    );
}