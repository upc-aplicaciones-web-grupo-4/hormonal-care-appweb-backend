namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public record ProfessionalIdentificationNumber(string professionalIdentificationNumber)
{
    public ProfessionalIdentificationNumber() : this(string.Empty)
    {
        
    }
}


