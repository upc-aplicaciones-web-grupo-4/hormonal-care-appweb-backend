namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record UpdateDoctorRecourse(
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
