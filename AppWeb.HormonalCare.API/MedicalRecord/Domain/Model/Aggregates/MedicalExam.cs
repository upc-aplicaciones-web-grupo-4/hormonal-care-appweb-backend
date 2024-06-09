using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class MedicalExam
{
    public MedicalExam()
    {
        Name = new MedicalExamName();
    }
    public MedicalExam(string name, int typeExamId)
    {
        Name = new MedicalExamName(name);
        TypeExamId = typeExamId;
    }
    public MedicalExam(CreateMedicalExamCommand command, TypeExam typeExam)
    {
        Name = new MedicalExamName(command.Name);
        TypeExam = typeExam;
    }

    public int Id { get; }
    public MedicalExamName Name { get; private set; }

    
    
    public TypeExam TypeExam { get; private set; }
    public int TypeExamId { get; private set; }
    

    public string ExamName => Name.ExamName;

 
}