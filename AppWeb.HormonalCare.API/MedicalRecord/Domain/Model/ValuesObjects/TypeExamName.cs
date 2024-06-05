namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public record TypeExamName(string TypeName)
{
    public TypeExamName() : this(string.Empty)
    {
    }
}