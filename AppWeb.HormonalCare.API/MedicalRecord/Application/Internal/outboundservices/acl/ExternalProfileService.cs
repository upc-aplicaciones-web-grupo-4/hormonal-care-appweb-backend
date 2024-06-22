using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;
using AppWeb.HormonalCare.API.Profiles.Interfaces.ACL;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.outboundservices.acl;

public class ExternalProfileService(IProfilesContextFacade profilesContextFacade)
{
    public async Task<int?> FetchProfileIdByEmail(string email)
    {
        var profileId = await profilesContextFacade.FetchProfileIdByEmail(email);
        if (profileId == 0) return null;
        return profileId;
    }
    
    
    public async Task<int?> CreateProfile(string firstName,
        string lastName,
        string image,
        string gender,
        DateTime birthDate,
        string phone, 
        string email)
    {
        var profileId = await profilesContextFacade.CreateProfile(firstName, 
            lastName,
            image,
            gender,
            birthDate,
            phone,
            email);
        if (profileId == 0) return null;
        return profileId;
    }
}