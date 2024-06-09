using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices;

public class MedicalAppointmentQueryService(IMedicalAppointmentRepository medicalAppointmentRepository) : IMedicalAppointmentQueryService
{
    public async Task<IEnumerable<MedicalAppointment>> Handle(GetAllMedicalAppointmentQuery query)
    {
        return await medicalAppointmentRepository.ListAsync();
    }

    public async Task<MedicalAppointment?> Handle(GetMedicalAppointmentByIdQuery query)
    {
        return await medicalAppointmentRepository.FindByIdAsync(query.id);
    }
}











