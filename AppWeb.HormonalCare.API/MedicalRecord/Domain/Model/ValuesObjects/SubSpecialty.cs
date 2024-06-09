namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public record SubSpecialty(string subSpecialty)
{
    public SubSpecialty() : this(string.Empty)
    {
    }
}


