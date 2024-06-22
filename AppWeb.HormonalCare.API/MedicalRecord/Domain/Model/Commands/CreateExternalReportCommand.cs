using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public class CreateExternalReportCommand
{
    public int ReportTypeId { get; set; }

    public async Task<ExternalReport?> Handle(CreateExternalReportCommand command)
    {
        var externalReport = new ExternalReport 
        { 
            ReportTypeId = command.ReportTypeId 
        };
    
        return externalReport;
    }
}