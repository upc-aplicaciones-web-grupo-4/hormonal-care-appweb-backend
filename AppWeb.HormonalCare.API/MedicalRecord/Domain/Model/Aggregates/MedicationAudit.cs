using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates
{
    public partial class Medication : IEntityWithCreatedUpdatedDate
    {
        [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }

        [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
        
    }
}