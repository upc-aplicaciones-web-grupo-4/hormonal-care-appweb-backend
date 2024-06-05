using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public static class MedicalExamResourceFromEntityAssembler
{
    public static MedicalExamResource ToResourceFromEntity(MedicalExam entity)
    {
        return new MedicalExamResource(
            entity.Id, 
            entity.ExamName,
            TypeExamResourceFromEntityAssembler.ToResourceFromEntity(entity.TypeExam)
        );
    }
}