using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class MedicalRecord
{
    public int Id { get; }
    
    //[ForeignKey("ReasonOfConsultationId")]
    private ReasonOfConsultation ReasonOfConsultation { get; set; }
    
    public int ReasonOfConsultationId { get; private set; } 

    public MedicalRecord()
    {
        this.ReasonOfConsultation = new ReasonOfConsultation();
    }

    public MedicalRecord(ReasonOfConsultation reasonOfConsultation)
    {
        this.ReasonOfConsultation = reasonOfConsultation;
        this.ReasonOfConsultationId = ReasonOfConsultation.Id();
    }

    public int GetReasonOfConsultationId()
    {
        return this.ReasonOfConsultation.Id;
    }
}