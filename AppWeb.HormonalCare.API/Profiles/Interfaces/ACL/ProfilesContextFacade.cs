using AppWeb.HormonalCare.API.Profiles.Domain.Model.Commands;
using AppWeb.HormonalCare.API.Profiles.Domain.Model.Queries;
using AppWeb.HormonalCare.API.Profiles.Domain.Model.Services;
using AppWeb.HormonalCare.API.Profiles.Domain.Model.ValueObjects;

namespace AppWeb.HormonalCare.API.Profiles.Interfaces.ACL;

/**
 * Profiles context facade.
 *
 * <summary>
 * This class represents the profiles context facade, part of the profiles anti-corruption layer.
 * It contains the methods to interact with the profiles context from other bounded context.
 * </summary>
 */
public class ProfilesContextFacade(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService)
{
    /**
     * Create a profile.
     *
     * <param name="firstName">The first name of the profile</param>
     * <param name="lastName">The last name of the profile</param>
     * <param name="email">The email of the profile</param>
     * <param name="street">The street of the profile</param>
     * <param name="number">The number of the profile</param>
     * <param name="city">The city of the profile</param>
     * <param name="postalCode">The postal code of the profile</param>
     * <param name="country">The country of the profile</param>
     * <returns>The profile id</returns>
     * 
     */
    public async Task<int> CreateProfile(
        string firstName, 
        string lastName, 
        string image, 
        string gender, 
        DateTime birthDate, 
        string phone, 
        string email)
    {
        var createProfileCommand = new CreateProfileCommand(firstName, 
            lastName, 
            image, 
            gender, 
            birthDate, 
            phone, 
            email);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }
    
    /**
     * Fetch a profile id by email.
     *
     * <param name="email">The email of the profile</param>
     * <returns>The profile id</returns>
     * 
     */
    public async Task<int> FetchProfileIdByEmail(string email)
    {
        var getProfileByEmailQuery = new GetProfileByEmailQuery(new EmailAddress(email));
        var profile = await profileQueryService.Handle(getProfileByEmailQuery);
        return profile?.Id ?? 0;
    }
}