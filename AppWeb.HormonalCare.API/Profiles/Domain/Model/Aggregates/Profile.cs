using AppWeb.HormonalCare.API.Profiles.Domain.Model.Commands;
using AppWeb.HormonalCare.API.Profiles.Domain.Model.ValueObjects;

namespace AppWeb.HormonalCare.API.Profiles.Domain.Model.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;
/**
 * Profile aggregate root entity.
 *
 * <p>
 * This class represents the Profile aggregate root entity. It contains the properties and methods to manage the profile
 * </p>
 */
public partial class Profile
{
    public Profile()
    {
        Name = new PersonName();
        Image = new Image();
        Gender = new Gender();
        BirthDate = new BirthDate();
        Phone = new PhoneNumber();
        Email = new EmailAddress();
    }

    public Profile(string firstName, string lastName, string image, string gender, DateTime birthdate, string phone, string email)
    {
        Name = new PersonName(firstName, lastName);
        Image = new Image(image);
        Gender = new Gender(gender);
        BirthDate = new BirthDate(birthdate);
        Phone = new PhoneNumber(phone);
        Email = new EmailAddress(email);
    }

    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Image = new Image(command.Image);
        Gender = new Gender(command.Gender);
        BirthDate = new BirthDate(command.BirthDate);
        Phone = new PhoneNumber(command.Phone);
        Email = new EmailAddress(command.Email);
        
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; }
    public PersonName Name { get; private set; }
    public Image Image { get; private set; }
    public Gender Gender { get; private set; }
    public BirthDate BirthDate { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public EmailAddress Email { get; private set; }
    

    public string FullName => Name.FullName;
    public string ImageUrl => Image.Url;
    public string GenderValue => Gender.Value;
    public DateTime BirthDateValue => BirthDate.Value;
    public string PhoneNumber => Phone.Number;
    public string EmailAddress => Email.Address;

}