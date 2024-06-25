using System.ComponentModel.DataAnnotations.Schema;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class MedicalRecord
{
    public int Id { get; set; }
    
    public Patient Patient { get;  set; }

    public int PatientId { get;  set; }
    
    
    
    public MedicalRecord()
    {
        PatientId = 0;
    }

    public MedicalRecord(int patientId): this()
    {
        PatientId = patientId;
    }
    public MedicalRecord(Patient patient)
    {
        Patient = patient;
    }
    
    public ICollection<MedicalExam> MedicalExams { get; private set; }
    public ICollection<MedicalExam> ReasonOfConsultations { get; private set; }
    public ICollection<MedicalExam> Treatments { get; private set; }
}
