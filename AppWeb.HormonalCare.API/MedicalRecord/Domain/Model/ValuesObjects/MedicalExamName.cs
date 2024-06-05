namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public record MedicalExamName(string ExamName)
{
    public MedicalExamName() : this(string.Empty)
    {
    }
}