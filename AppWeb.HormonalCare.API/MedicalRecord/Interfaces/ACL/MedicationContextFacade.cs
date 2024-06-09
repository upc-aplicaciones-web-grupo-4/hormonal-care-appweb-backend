/*using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.ACL;

public class MedicationContextFacade
{
    private IMedicationCommandService medicationCommandService;
    private IMedicationQueryService medicationQueryService;

    public MedicationContextFacade(IMedicationCommandService medicationCommandService, IMedicationQueryService medicationQueryService)
    {
        this.medicationCommandService = medicationCommandService;
        this.medicationQueryService = medicationQueryService;
    }

    public async Task<int> CreateMedication(int prescriptionId, int medicationTypeId, string drugName, int quantity, string concentration, int frequency, string duration)
    {
        var createMedicationCommand = new CreateMedicationCommand(prescriptionId, medicationTypeId, drugName, quantity, concentration, frequency, duration);
        var medication = await medicationCommandService.Handle(createMedicationCommand);
        return medication?.Id ?? 0;
    }

    public async Task<int> FetchMedicationIdByPrescriptionId(int prescriptionId)
    {
        var getMedicationByPrescriptionIdQuery = new GetMedicationsByPrescriptionIdQuery(prescriptionId);
        var medication = await medicationQueryService.Handle(getMedicationByPrescriptionIdQuery);
        return medication?.Id ?? 0;
    }

    public async Task<int> FetchMedicationIdByMedicationTypeId(int medicationTypeId)
    {
        var getMedicationByMedicationTypeIdQuery = new GetMedicationsByMedicationTypeIdQuery(medicationTypeId);
        var medication = await medicationQueryService.Handle(getMedicationByMedicationTypeIdQuery);
        return medication?.Id ?? 0;
    }
}
*/