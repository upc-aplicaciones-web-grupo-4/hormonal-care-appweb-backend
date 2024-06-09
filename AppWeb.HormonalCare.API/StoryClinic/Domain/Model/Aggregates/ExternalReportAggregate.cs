using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Aggregates;

public class ExternalRerportAggregate
{
    public ExternalReport ExternalReport { get; set; }
    public ReportType ReportType { get; set; }
}