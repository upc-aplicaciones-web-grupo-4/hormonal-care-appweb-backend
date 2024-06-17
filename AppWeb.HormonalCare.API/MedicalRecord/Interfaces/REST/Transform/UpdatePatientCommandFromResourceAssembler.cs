﻿using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class UpdatePatientCommandFromResourceAssembler
{
    public static UpdatePatientCommand ToCommandFromResource(int id, UpdatePatientResource resource)
    {
        return new UpdatePatientCommand(id, 
            resource.FirstName,
            resource.LastName,
            resource.Image,
            resource.Gender,
            resource.BirthDate,
            resource.Phone,
            resource.Email,
            resource.TypeofBloodName);
    }

}

