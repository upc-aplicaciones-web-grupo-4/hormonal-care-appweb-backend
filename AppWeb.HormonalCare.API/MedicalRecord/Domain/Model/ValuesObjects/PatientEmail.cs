using System;
using System.Text.RegularExpressions;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

public record PatientEmail(string email)
{
    public PatientEmail() : this(string.Empty)
    {
    }
    
    private static bool IsValidEmail(string email)
    {
        string emailRegex = @"^[A-Za-z0-9+_.-]+@(.+)$";
        return Regex.IsMatch(email, emailRegex);
    }
}