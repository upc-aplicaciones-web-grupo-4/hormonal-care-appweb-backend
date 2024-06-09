namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public record ProfileId(int profileId)
{
    public ProfileId() : this(0)
    {
    }
}

