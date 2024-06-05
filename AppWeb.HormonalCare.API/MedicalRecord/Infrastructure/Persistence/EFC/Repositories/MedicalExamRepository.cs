﻿using AppWeb.HormonalCare.API.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;
using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories;

public class MedicalExamRepository(AppDbContext context) : BaseRepository<MedicalExam>(context), IMedicalExamRepository
{
    public Task<MedicalExam?> FindMedicalExamByNameAsync(MedicalExamName name)
    {
        return Context.Set<MedicalExam>()
            .Where(t => t.Name == name).FirstOrDefaultAsync();
    }
}
