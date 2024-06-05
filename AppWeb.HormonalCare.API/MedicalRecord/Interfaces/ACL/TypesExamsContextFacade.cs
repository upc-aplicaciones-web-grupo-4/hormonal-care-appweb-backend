using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.ACL;

public class TypesExamsContextFacade(ITypeExamCommandService typeexamCommandService,ITypeExamQueryService typeExamQueryService)   
{
    public async Task<int> CreateTypeExam(string typeName)
    {
        var createTypeExamCommand = new CreateTypeExamCommand(typeName);
        var typeExam = await typeexamCommandService.Handle(createTypeExamCommand);
        return typeExam?.Id ?? 0;
    }
    public async Task<int> FetchTypeExamIdByName(string name)
    {
        var getTypeExamByNameQuery = new GetTypeExamByNameQuery(new TypeExamName(name));
        var typeExam = await typeExamQueryService.Handle(getTypeExamByNameQuery);
        return typeExam?.Id ?? 0;
    }
}