using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.ACL;

public class PrescriptionContextFacade(IPrescriptionCommandService prescriptionCommandService, IPrescriptionQueryService prescriptionQueryService)   
{
    public async Task<int> CreatePrescription( int DoctorId, int PatientId, DateTime prescriptionDate, string notes)
    {
        var createPrescriptionCommand = new CreatePrescriptionCommand( DoctorId, PatientId, prescriptionDate, notes);
        var prescription = await prescriptionCommandService.Handle(createPrescriptionCommand);
        return prescription?.Id ?? 0;
    }
}