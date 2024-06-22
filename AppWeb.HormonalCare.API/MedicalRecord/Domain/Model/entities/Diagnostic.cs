namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

public class Diagnostic
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int ReportTypeId { get; set; } 
    public int MedicalRecordId { get; set; }
    //FK de MedicalRecord
}