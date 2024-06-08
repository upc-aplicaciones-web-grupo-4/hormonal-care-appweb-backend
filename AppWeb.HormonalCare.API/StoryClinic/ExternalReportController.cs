using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb.HormonalCare.API.Publishing.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;


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
        return Ok(reports);
    }

    // Método POST
    [HttpPost]
    public async Task<IActionResult> CreateExternalReport(ExternalReport externalReport)
    {
        await _commandService.AddAsync(externalReport);
        await _commandService.CompleteAsync();
        return Ok();
    }
}