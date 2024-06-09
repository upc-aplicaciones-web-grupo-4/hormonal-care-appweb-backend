/*using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.ACL;

public class MedicationTypeContextFacade(IMedicationTypeCommandService medicationTypeCommandService, IMedicationTypeQueryService medicationTypeQueryService)   
{
    public async Task<int> CreateMedicationType(string medicationTypeName)
    {
        var createMedicationTypeCommand = new CreateMedicationTypeCommand(medicationTypeName);
        var medicationType = await medicationTypeCommandService.Handle(createMedicationTypeCommand);
        return medicationType?.Id ?? 0;
    }
}*/