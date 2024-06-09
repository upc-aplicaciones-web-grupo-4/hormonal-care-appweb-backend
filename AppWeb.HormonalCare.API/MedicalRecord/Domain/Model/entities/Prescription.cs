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

        public Prescription() { }

        public Prescription(DateTime prescriptionDate, int doctorId, int patientId, string notes)
        {
            PrescriptionDate = prescriptionDate;
            DoctorId = doctorId;
            PatientId = patientId;
            Notes = notes;
        }

        public Prescription(CreatePrescriptionCommand command)
        {
            PrescriptionDate = command.PrescriptionDate;
            DoctorId = command.DoctorId;
            PatientId = command.PatientId;
            Notes = command.Notes;
        }
        
        public Prescription Update( int doctorId, int patientId,DateTime prescriptionDate, string notes)
        {
            PrescriptionDate = prescriptionDate;
            DoctorId = doctorId;
            PatientId = patientId;
            Notes = notes;
            return this;
        }

        public ICollection<Medication> Medications { get; set; }
    

    }
}