namespace AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;

public class ExternalReport
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int ReportTypeId { get; set; } 
    public ReportType ReportType { get; set; } 
}