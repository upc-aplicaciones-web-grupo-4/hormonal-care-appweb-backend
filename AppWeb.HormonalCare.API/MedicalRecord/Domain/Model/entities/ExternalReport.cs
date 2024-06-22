namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

public class ExternalReport
{
    public int Id { get; set; }
    public int ReportTypeId { get; set; } 
    public int MedicalRecordId { get; set; }

}