using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record DiagnosticResource(
    int Id,
    string Description,
    int ReportTypeId,
    int MedicalRecordId
    );
