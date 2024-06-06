using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            TypeName = command.typeName;
        }

        public void UpdateTypeName(string typeName)
        {
            TypeName = typeName;
        }

        public string GetName()
        {
            return TypeName;
        }

        public void Update(UpdateMedicationTypeCommand command)
        {
            throw new NotImplementedException();
        }
        
    }
}