using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public DateTime PrescriptionDate { get; set; }
        public string Notes { get; set; }

      public Prescription()
      {
        
      }

        public Prescription(int doctorId, int patientId, DateTime prescriptionDate, string notes)
        {
            DoctorId = doctorId;
            PatientId = patientId;
            PrescriptionDate = prescriptionDate;
            Notes = notes;
        }

        public Prescription(CreatePrescriptionCommand command)
        {
            DoctorId = command.DoctorId;
            PatientId = command.PatientId;
            PrescriptionDate = command.PrescriptionDate;
            Notes = command.Notes;
        }
        
        public ICollection<Medication> Medications { get; set; }

        public Prescription Update( int doctorId, int patientId,DateTime prescriptionDate, string notes)
        {
            PrescriptionDate = prescriptionDate;
            DoctorId = doctorId;
            PatientId = patientId;
            Notes = notes;
            return this;
        }
        
    

    }
}