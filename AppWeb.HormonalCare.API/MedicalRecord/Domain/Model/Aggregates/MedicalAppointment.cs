using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class MedicalAppointment
{
    public MedicalAppointment()
    {
        eventDate = new EventDate();
        startTime = new StartTime();
        endTime = new EndTime();
        tittle = string.Empty;
        description = string.Empty;
        doctorEmail = new DoctorEmail();
        patientEmail = new PatientEmail();
    }
    
    public MedicalAppointment(DateTime eventDate, string startTime, string endTime, string tittle, string description, string doctorEmail, string patientEmail)
    {
        this.eventDate = new EventDate(eventDate);
        this.startTime = new StartTime(startTime);
        this.endTime = new EndTime(endTime);
        this.tittle = tittle;
        this.description = description;
        this.doctorEmail = new DoctorEmail(doctorEmail);
        this.patientEmail = new PatientEmail(patientEmail);
    }
    
    public MedicalAppointment(CreateMedicalAppointmentCommand command)
    {
        eventDate = new EventDate(command.eventDate);
        startTime = new StartTime(command.startTime);
        endTime = new EndTime(command.endTime);
        tittle = command.tittle;
        description = command.description;
        doctorEmail = new DoctorEmail(command.doctorEmail);
        patientEmail = new PatientEmail(command.patientEmail);
    }
    
    public void UpdateInformation(UpdateMedicalAppointmentCommand command)
    {
        eventDate = new EventDate(command.eventDate);
        startTime = new StartTime(command.startTime);
        endTime = new EndTime(command.endTime);
        tittle = command.tittle;
        description = command.description;
        doctorEmail = new DoctorEmail(command.doctorEmail);
        patientEmail = new PatientEmail(command.patientEmail);
    }
    
    public int Id { get; set; }
    public EventDate eventDate { get; set; }
    public StartTime startTime { get; set; }
    public EndTime endTime { get; set; }
    public string tittle { get; set; }
    public string description { get; set; }
    public DoctorEmail doctorEmail { get; set; }
    public PatientEmail patientEmail { get; set; }
}