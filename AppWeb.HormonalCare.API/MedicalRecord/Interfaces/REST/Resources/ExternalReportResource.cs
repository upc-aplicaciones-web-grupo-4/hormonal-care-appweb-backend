using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record ExternalReportResource(
    int Id,
    int ReportTypeId,
    int MedicalRecordId
    );