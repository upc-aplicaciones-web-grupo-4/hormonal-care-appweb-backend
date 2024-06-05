using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class TypeExam
{
    
    
    public TypeExam()
    {
        Name = new TypeExamName();
        MedicalExams = new List<MedicalExam>();
    }

    public TypeExam(string name)
    {
        Name = new TypeExamName(name);
        MedicalExams = new List<MedicalExam>();
    }

    public TypeExam(CreateTypeExamCommand command)
    {
        Name = new TypeExamName(command.Name);
        MedicalExams = new List<MedicalExam>();
    }

    public int Id { get; private set; }
    public TypeExamName Name { get; private set; }

    // Navigation Property
    public ICollection<MedicalExam> MedicalExams { get; private set; }
    public string TypeName => Name.TypeName;
    
    // Agrega aquí otras propiedades según sea necesario
}