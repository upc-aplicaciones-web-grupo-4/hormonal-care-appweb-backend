using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices;

public class PatientQueryService(IPatientRepository patientRepository) : IPatientQueryService
{

    public async Task<IEnumerable<Patient>> Handle(GetAllPatientsQuery query)
    {
        return await patientRepository.ListAsync();
    }

    public async Task<Patient?> Handle(GetPatientByIdQuery query)
    {
        return await patientRepository.FindByIdAsync(query.PatientId);
    }
    
    public async Task<Patient?> Handle(GetPatientByProfileIdQuery query)
    {
        return await patientRepository.FindByProfileIdAsync(query.ProfileId);
    }
    
    public async Task<Patient?> Handle(GetPatientByPatientRecordIdQuery query)
    {
        return await patientRepository.FindByPatientRecordIdAsync(new PatientRecord(query.PatientRecordId));
    }
}
