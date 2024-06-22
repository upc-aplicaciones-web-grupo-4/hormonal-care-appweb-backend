namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public class PatientRecord
{
    public int Id { get; private set; }  // Propiedad para mapeo con EF

    public string RecordId { get; private set; }

    // Constructor que inicializa RecordId
    public PatientRecord()
    {
        RecordId = Guid.NewGuid().ToString();
    }

    public PatientRecord(string recordId)
    {
        if (string.IsNullOrWhiteSpace(recordId))
        {
            throw new ArgumentException("Patient record ID cannot be null or blank", nameof(recordId));
        }
        RecordId = recordId;
    }

    public void Deconstruct(out string recordId)
    {
        recordId = RecordId;
    }
}
