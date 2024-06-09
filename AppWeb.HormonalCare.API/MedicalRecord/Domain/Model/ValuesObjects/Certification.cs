namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public record Certification(string certification)
{
    public Certification() : this(string.Empty)
    {
    }
}


