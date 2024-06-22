using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform
{
    public class DiagnosticTransform
    {
        public DiagnosticResource ToResource(Diagnostic diagnostic)
        {
            return new DiagnosticResource(
                diagnostic.Id,
                diagnostic.Description,
                diagnostic.ReportTypeId,
                diagnostic.MedicalRecordId
            );
        }

        public Diagnostic ToEntity(DiagnosticResource diagnosticResource)
        {
            return new Diagnostic
            {
                Id = diagnosticResource.Id,
                Description = diagnosticResource.Description,
                ReportTypeId = diagnosticResource.ReportTypeId,
                MedicalRecordId = diagnosticResource.MedicalRecordId
            };
        }
    }
}