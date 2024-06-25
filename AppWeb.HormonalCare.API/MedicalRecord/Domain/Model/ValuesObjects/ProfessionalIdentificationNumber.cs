namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public record ProfessionalIdentificationNumber(int professionalIdentificationNumber)
{
    public ProfessionalIdentificationNumber() : this(0)
    {
        
    }
}


