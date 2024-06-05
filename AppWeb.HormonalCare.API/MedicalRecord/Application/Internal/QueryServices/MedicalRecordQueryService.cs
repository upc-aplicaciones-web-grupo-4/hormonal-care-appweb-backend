using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;

namespace AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices;

public class MedicalRecordQueryService (IMedicalRecordRepository medicalRecordRepository, IUnitOfWork unitOfWork): IMedicalRecordQueryService
{
    public async Task<Domain.Model.Aggregates.MedicalRecord?> Handle(GetMedicalRecordByIdQuery query)
    {
        return await medicalRecordRepository.FindByIdAsync(query.Id);
    }
}
