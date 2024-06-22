using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

[Route("/api/v1/[controller]")]
[ApiController]
public class ExternalReportController : ControllerBase
{
    private readonly iExternalReportCommandService _commandService;
    private readonly iExternalReportQueryService _queryService;

    public ExternalReportController(iExternalReportCommandService commandService, iExternalReportQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    // Método GET
    [HttpGet]
    public async Task<IActionResult> GetExternalReports()
    {
        IEnumerable<ExternalReport> reports = await _queryService.ListAsync();

        var transform = new ExternalReportTransform();
        var reportResources = reports.Select(transform.ToResource);

        return Ok(reportResources);
    }

    // Método POST
    [HttpPost]
    public async Task<IActionResult> CreateExternalReport([FromBody] ExternalReportResource reportResource)
    {
        var transform = new ExternalReportTransform();
        var externalReport = transform.ToEntity(reportResource);

        await _commandService.AddAsync(externalReport);
        await _commandService.CompleteAsync();
        return Ok();
    }
}