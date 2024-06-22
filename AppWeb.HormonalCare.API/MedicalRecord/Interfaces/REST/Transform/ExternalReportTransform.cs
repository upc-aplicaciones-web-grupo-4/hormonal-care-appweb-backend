using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform
{
    public class ExternalReportTransform
    {
        public ExternalReportResource ToResource(ExternalReport externalReport)
        {
            return new ExternalReportResource(
                externalReport.Id,
                externalReport.ReportTypeId,
                externalReport.MedicalRecordId
            );
        }

        public ExternalReport ToEntity(ExternalReportResource externalReportResource)
        {
            return new ExternalReport
            {
                Id = externalReportResource.Id,
                ReportTypeId = externalReportResource.ReportTypeId,
                MedicalRecordId = externalReportResource.MedicalRecordId
            };
        }
    }
}