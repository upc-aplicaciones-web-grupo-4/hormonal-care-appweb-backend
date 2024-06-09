namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record MedicalExamResource(
    int Id,
    string Name,
    //int TypeExamIdentifier
    TypeExamResource TypeExam,
    MedicalRecordResource MedicalRecord)
{
}