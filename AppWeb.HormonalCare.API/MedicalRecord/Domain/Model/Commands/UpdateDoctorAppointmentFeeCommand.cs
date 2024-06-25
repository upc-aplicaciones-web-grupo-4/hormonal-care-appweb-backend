namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

public record UpdateDoctorCommand(
    int id,
    string FirstName, 
    string LastName, 
    string Image, 
    string Gender, 
    DateTime BirthDate, 
    string Phone, 
    string Email,
    int appointmentFee,
    int subscriptionId
    );