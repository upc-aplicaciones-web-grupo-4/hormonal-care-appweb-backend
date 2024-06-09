namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record UpdatePatientCommand(int Id, string TypeofBloodName);