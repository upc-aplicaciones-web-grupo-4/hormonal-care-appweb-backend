using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class Patient
{
    public Patient()
    {
        TypeofBloodName = new TypeofBlood();
    }

    public Patient(string typeofBloodName): this()
    {
        TypeofBloodName = new TypeofBlood(typeofBloodName);
    }

    public Patient(CreatePatientCommand command)
    {
        TypeofBloodName = new TypeofBlood(command.TypeofBloodName);
    }
    public void Update(UpdatePatientCommand command)
    {
        TypeofBloodName = new TypeofBlood(command.TypeofBloodName);
    }
    
    
    public int Id { get; private set; }
    public TypeofBlood TypeofBloodName { get; private set; }
    public string TypeofBloodN => TypeofBloodName.TypeofBloodN;
}