using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record PatientResource(int Id, string TypeofBloodName);