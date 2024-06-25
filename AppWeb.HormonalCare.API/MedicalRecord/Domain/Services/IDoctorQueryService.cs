using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface IDoctorQueryService
{
    Task<IEnumerable<Doctor>> Handle(GetAllDoctorsQuery query);
    Task<Doctor?> Handle(GetDoctorByIdQuery query);
    Task<Doctor?> Handle(GetDoctorByProfileIdQuery query);
}