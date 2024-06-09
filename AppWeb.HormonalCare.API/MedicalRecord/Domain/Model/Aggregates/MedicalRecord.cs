using System.ComponentModel.DataAnnotations.Schema;

namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;

public partial class MedicalRecord
{
    public int Id { get; set; }
    
    //public ReasonOfConsultation ReasonOfConsultation { get; set; }

    public int ReasonOfConsultationId { get; set; }
    
    
    
    public MedicalRecord()
    {
        //this.ReasonOfConsultation = new ReasonOfConsultation();
    }

    public MedicalRecord(ReasonOfConsultation reasonOfConsultation)
    {
        //this.ReasonOfConsultation = reasonOfConsultation;
        ReasonOfConsultationId = reasonOfConsultation.Id;
    }
}
