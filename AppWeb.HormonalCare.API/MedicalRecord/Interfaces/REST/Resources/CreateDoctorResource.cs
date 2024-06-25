﻿namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record CreateDoctorResource(
    string FirstName, 
    string LastName, 
    string Image, 
    string Gender, 
    DateTime BirthDate, 
    string Phone, 
    string Email,
    int ProfessionalIdentificationNumber,
    string SubSpecialty,
    string Certification,
    int AppointmentFee,
    int SubscriptionId
    );