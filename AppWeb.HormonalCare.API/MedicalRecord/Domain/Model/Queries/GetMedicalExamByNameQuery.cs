using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;

public record GetMedicalExamByNameQuery(MedicalExamName Name);