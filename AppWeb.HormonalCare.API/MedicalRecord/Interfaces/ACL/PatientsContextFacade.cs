using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.ACL;

public class PatientsContextFacade(IPatientCommandService patientCommandService, IPatientQueryService patientQueryService)
{/*
    public async Task<int> CreatePatient(string typeofBloodName)
    {
        var createPatientCommand = new CreatePatientCommand(typeofBloodName,);
        var patient = await patientCommandService.Handle(createPatientCommand);
        return patient?.Id ?? 0;
    }
    
    public async Task<int> UpdatePatient(int id, string typeofBloodName)
    {
        var updatePatientCommand = new UpdatePatientCommand(id, typeofBloodName);
        var patient = await patientCommandService.Handle(updatePatientCommand);
        return patient?.Id ?? 0;
    }*/
}


