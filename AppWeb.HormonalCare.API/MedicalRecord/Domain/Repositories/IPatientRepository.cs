using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;

public interface IPatientRepository: IBaseRepository<Patient>
{
    Task<Patient?> FindByProfileIdAsync(int profileId);
    Task<Patient?> FindByPatientRecordIdAsync(PatientRecord patientRecordId);
}