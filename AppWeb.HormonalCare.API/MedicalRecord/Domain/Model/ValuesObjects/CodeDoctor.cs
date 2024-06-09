namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public record CodeDoctor(string codeDoctor)
{
    public CodeDoctor() : this(string.Empty)
    {
    }

    public string Value
    {
        get { return this.codeDoctor; }
    }
}