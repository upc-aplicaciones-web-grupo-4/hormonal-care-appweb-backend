﻿using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class CreateDoctorCommandFromResourceAssembler
{
    public static CreateDoctorCommand ToCommandFromResource(CreateDoctorResource resource)
    {
        return new CreateDoctorCommand(
            resource.FirstName,
            resource.LastName,
            resource.Image,
            resource.Gender,
            resource.BirthDate,
            resource.Phone,
            resource.Email,
            resource.ProfessionalIdentificationNumber, 
            resource.SubSpecialty,
            resource.Certification,
            resource.AppointmentFee,
            resource.SubscriptionId
            );
    }
}