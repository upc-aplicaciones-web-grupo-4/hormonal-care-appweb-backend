using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface IMedicalAppointmentQueryService
{
    Task<IEnumerable<MedicalAppointment>> Handle(GetAllMedicalAppointmentQuery query);
    Task<MedicalAppointment?> Handle(GetMedicalAppointmentByIdQuery query);
}



