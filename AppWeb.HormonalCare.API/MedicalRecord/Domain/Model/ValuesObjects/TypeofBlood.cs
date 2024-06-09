namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public record TypeofBlood(string TypeofBloodN)
{
    public TypeofBlood() : this(string.Empty)
    {
    }
}


