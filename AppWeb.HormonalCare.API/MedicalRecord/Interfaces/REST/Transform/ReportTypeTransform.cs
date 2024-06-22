using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform
{
    public class ReportTypeTransform
    {
        public ReportTypeResource ToResource(ReportType reportType)
        {
            return new ReportTypeResource(
                reportType.Id,
                reportType.Name
            );
        }

        public ReportType ToEntity(ReportTypeResource reportTypeResource)
        {
            return new ReportType
            {
                Id = reportTypeResource.Id,
                Name = reportTypeResource.Name
            };
        }
    }
}