using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using Google.Protobuf.WellKnownTypes;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates
{
    public partial class Medication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [ForeignKey("Prescription")] public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        [ForeignKey("MedicationType")] public int MedicationTypeId { get; set; }
        public MedicationType MedicationType { get; set; }

        [Required(ErrorMessage = "DrugName is required.")]
        [StringLength(100, ErrorMessage = "DrugName can't be longer than 100 characters.")]
        public string DrugName { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Concentration is required.")]
        [StringLength(100, ErrorMessage = "Concentration can't be longer than 100 characters.")]
        public string Concentration { get; set; }

        [Required(ErrorMessage = "Frequency is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Frequency must be greater than 0.")]
        public int Frequency { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        [StringLength(100, ErrorMessage = "Duration can't be longer than 100 characters.")]
        public string Duration { get; set; }

        
        public Medication()
        {
            
        }
        public Medication(CreateMedicationCommand command, Prescription prescription, MedicationType medicationType)
        {
            //Name = new MedicalExamName(command.Name);
            DrugName = command.DrugName;
            Quantity = command.Quantity;
            Concentration = command.Concentration;
            Frequency = command.Frequency;
            Duration = command.Concentration;
            Prescription = prescription;
            MedicationType = medicationType;
        }

        public Medication(int prescriptionId, int medicationTypeId, string drugName, int quantity, string concentration,
            int frequency, string duration)
        {
            // Name = new MedicalExamName(name);
            
            Prescription = new Prescription () {Id = prescriptionId};
            MedicationType = new MedicationType() {Id = medicationTypeId};
            DrugName = drugName;
            Quantity = quantity;
            Concentration = concentration;
            Frequency = frequency;
            Duration = duration;
        }



        public void Update(UpdateMedicationCommand command, Prescription prescription, MedicationType medicationType)
        {
            Prescription = prescription;
            MedicationType = medicationType;
            DrugName = command.DrugName;
            Quantity = command.Quantity;
            Concentration = command.Concentration;
            Frequency = command.Frequency;
            Duration = command.Duration;
        }
    }
}