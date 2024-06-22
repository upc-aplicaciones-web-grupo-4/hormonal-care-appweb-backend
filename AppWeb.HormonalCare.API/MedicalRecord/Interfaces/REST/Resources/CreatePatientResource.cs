namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record CreatePatientResource(
    string FirstName, 
    string LastName, 
    string Image, 
    string Gender, 
    DateTime BirthDate, 
    string Phone, 
    string Email,
    string TypeofBloodName);