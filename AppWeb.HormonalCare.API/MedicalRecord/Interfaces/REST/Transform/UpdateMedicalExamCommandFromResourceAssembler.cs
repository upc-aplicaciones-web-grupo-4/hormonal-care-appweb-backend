using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public class UpdateMedicalExamCommandFromResourceAssembler {
    public static UpdateMedicalExamCommand ToCommandFromResource(int id, UpdateMedicalExamResource resource)
    {
        return new UpdateMedicalExamCommand(id, resource.Name, resource.TypeExamIdentifier, resource.MedicalRecordIdentifier);
    }
    
}

