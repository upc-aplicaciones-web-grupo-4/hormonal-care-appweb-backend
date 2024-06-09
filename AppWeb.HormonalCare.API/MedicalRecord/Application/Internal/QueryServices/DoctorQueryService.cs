using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices;

public class DoctorQueryService(IDoctorRepository doctorRepository) : IDoctorQueryService
{
    public async Task<IEnumerable<Doctor>> Handle(GetAllDoctorsQuery query)
    {
        return await doctorRepository.ListAsync();
    }

    public async Task<Doctor?> Handle(GetDoctorByIdQuery query)
    {
        return await doctorRepository.FindByIdAsync(query.DoctorId);
    }
}
