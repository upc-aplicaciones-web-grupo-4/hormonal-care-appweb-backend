using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Commands;

public class CreateExternalReportCommand
{
    public string Description { get; set; } 
    public int ReportTypeId { get; set; }

    public async Task<ExternalReport?> Handle(CreateExternalReportCommand command)
    {
        var externalReport = new ExternalReport 
        { 
            Description = command.Description,
            ReportTypeId = command.ReportTypeId 
        };
    
        return externalReport;
    }
}