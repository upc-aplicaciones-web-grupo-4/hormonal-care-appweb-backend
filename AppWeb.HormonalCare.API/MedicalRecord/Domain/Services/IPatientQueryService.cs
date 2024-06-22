using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public interface IPatientQueryService
{
    Task<IEnumerable<Patient>> Handle(GetAllPatientsQuery query);
    Task<Patient?> Handle(GetPatientByIdQuery query);
    
    Task<Patient?> Handle(GetPatientByPatientRecordIdQuery query);
    Task<Patient?> Handle(GetPatientByProfileIdQuery query);
}