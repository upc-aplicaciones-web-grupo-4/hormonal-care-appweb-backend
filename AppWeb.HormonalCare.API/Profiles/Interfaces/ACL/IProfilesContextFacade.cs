namespace AppWeb.HormonalCare.API.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string firstName,
        string lastName,
        string image,
        string gender,
        DateTime birthDate,
        string phone,
        string email);

    Task<int> FetchProfileIdByEmail(string email);
}