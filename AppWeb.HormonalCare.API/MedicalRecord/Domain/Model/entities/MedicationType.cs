using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities
{
    public class MedicationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string TypeName { get; set; }

        public MedicationType() { }

        public MedicationType(CreateMedicationTypeCommand command)
        {
            TypeName = command.TypeName;
        }

        public MedicationType Update(string typeName)
        {
            TypeName = typeName;
            return this;
        }
        
        public string GetName()
        {
            return TypeName;
        }
        
        public ICollection<Medication> Medications { get; set; }


       
    }
}