using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class MedicalExam
{
    public MedicalExam()
    {
        Name = new MedicalExamName();
        TypeExamId = 0;
        MedicalRecordId = 0;
    }
    public MedicalExam(string name, int typeExamId, int medicalRecordId): this()
    {
        Name = new MedicalExamName(name);
        TypeExamId = typeExamId;
        MedicalRecordId = medicalRecordId;
    }
    public MedicalExam(CreateMedicalExamCommand command, TypeExam typeExam, MedicalRecord medicalRecord)
    {
        Name = new MedicalExamName(command.Name);
        TypeExam = typeExam;
        MedicalRecord = medicalRecord;
    }

    public void Update(UpdateMedicalExamCommand command, TypeExam typeExam, MedicalRecord medicalRecord)
    {
        Name = new MedicalExamName(command.Name);
        TypeExam = typeExam;
        MedicalRecord = medicalRecord;
    }


    public int Id { get; }
    public MedicalExamName Name { get; private set; }

    
    
    public TypeExam TypeExam { get; private set; }
    public int TypeExamId { get; private set; }
    

    public MedicalRecord MedicalRecord { get; private set; }
    
    public int MedicalRecordId { get; private set; }
    
    
    
    public string ExamName => Name.ExamName;

 
}