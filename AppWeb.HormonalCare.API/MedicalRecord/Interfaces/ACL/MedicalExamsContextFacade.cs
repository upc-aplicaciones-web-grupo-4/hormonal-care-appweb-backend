using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.ACL;

public class MedicalExamsContextFacade(IMedicalExamCommandService medicalexamCommandService,IMedicalExamQueryService medicalExamQueryService)   
{
    public async Task<int> CreateMedicalExam(string medicalName, int typeExamId, int medicalRecordId)
    {
        
        var createMedicalExamCommand = new CreateMedicalExamCommand(medicalName, typeExamId, medicalRecordId);
        var medicalExam = await medicalexamCommandService.Handle(createMedicalExamCommand);
        return medicalExam?.Id ?? 0;
    }
    public async Task<int> FetchMedicalExamIdByName(string name)
    {
        var getMedicalExamByNameQuery = new GetMedicalExamByNameQuery(new MedicalExamName(name));
        var medicalExam = await medicalExamQueryService.Handle(getMedicalExamByNameQuery);
        return medicalExam?.Id ?? 0;
    }
public async Task<int> UpdateMedicalExam(int id, string name, int typeExamId, int medicalRecordId)
    {
        var updateMedicalExamCommand = new UpdateMedicalExamCommand(id, name, typeExamId, medicalRecordId);
        var medicalExam = await medicalexamCommandService.Handle(updateMedicalExamCommand);
        return medicalExam?.Id ?? 0;
        
    }
    
}
