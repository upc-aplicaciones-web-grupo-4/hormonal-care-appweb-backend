namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record UpdatePatientCommand(int Id,
    string FirstName, 
    string LastName, 
    string Image, 
    string Gender, 
    DateTime BirthDate, 
    string Phone, 
    string Email,
    string TypeofBloodName);