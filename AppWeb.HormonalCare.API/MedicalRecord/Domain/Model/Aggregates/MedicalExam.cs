using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class MedicalExam
{
    public MedicalExam()
    {
        Name = new MedicalExamName();
        TypeExamId = 0;
    }
    public MedicalExam(string name, int typeExamId): this()
    {
        Name = new MedicalExamName(name);
        TypeExamId = typeExamId;
    }
    public MedicalExam(CreateMedicalExamCommand command, TypeExam typeExam)
    {
        Name = new MedicalExamName(command.Name);
        TypeExam = typeExam;
    }
    public void Update(UpdateMedicalExamCommand command, TypeExam typeExam)
    {
        Name = new MedicalExamName(command.Name);
        TypeExam = typeExam;
    }

    public int Id { get; }
    public MedicalExamName Name { get; private set; }

    
    
    public TypeExam TypeExam { get; private set; }
    public int TypeExamId { get; private set; }
    

    public string ExamName => Name.ExamName;

    // Agrega aquí otras propiedades según sea necesario
}