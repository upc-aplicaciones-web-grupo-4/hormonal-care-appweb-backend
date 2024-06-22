using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories;

public class DiagnosticRepository : IDiagnosticRepository
{
    private readonly AppDbContext _context;

    public DiagnosticRepository(AppDbContext context)
    {
        _context = context;
    }

    // Implementación de los métodos del repositorio
    public async Task<IEnumerable<Diagnostic>> GetAllDiagnosticsAsync()
    {
        return await _context.Set<Diagnostic>().ToListAsync();
    }

    public async Task<Diagnostic> CreateDiagnosticAsync(Diagnostic diagnostic)
    {
        _context.Set<Diagnostic>().Add(diagnostic);
        await _context.SaveChangesAsync();
        return diagnostic;
    }
}