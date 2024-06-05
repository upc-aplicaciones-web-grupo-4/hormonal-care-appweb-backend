using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

public static class TypeExamResourceFromEntityAssembler
{
    public static TypeExamResource ToResourceFromEntity(TypeExam entity)
    {

        return new TypeExamResource(
            entity.Id,
            entity.TypeName
        );
    }
}