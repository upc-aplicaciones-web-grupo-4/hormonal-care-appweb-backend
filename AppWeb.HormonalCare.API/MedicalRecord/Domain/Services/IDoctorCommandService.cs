using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface IDoctorCommandService
{
    Task<Doctor?> Handle(CreateDoctorCommand command);
    Task<Doctor?> Handle(UpdateDoctorCommand command);
}


