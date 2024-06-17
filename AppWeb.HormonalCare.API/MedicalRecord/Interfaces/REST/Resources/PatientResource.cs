using AppWeb.HormonalCare.API.Profiles.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record PatientResource(int Id, 
    string TypeofBloodName, 
    string PatientRecordId, 
    ProfileResource ProfileId);