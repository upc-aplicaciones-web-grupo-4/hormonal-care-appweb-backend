using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

namespace AppWeb.HormonalCare.API.MedicalRecord.REST
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class ReportTypeController : ControllerBase
    {
        private readonly IReportTypeCommandService _commandService;
        private readonly IReportTypeQueryService _queryService;

        public ReportTypeController(IReportTypeCommandService commandService, IReportTypeQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        // Método GET
        [HttpGet]
        public async Task<IActionResult> GetReportTypes()
        {
            IEnumerable<ReportType> reportTypes = await _queryService.ListAsync();

            var transform = new ReportTypeTransform();
            var reportTypeResources = reportTypes.Select(transform.ToResource);

            return Ok(reportTypeResources);
        }

        // Método POST
        [HttpPost]
        public async Task<IActionResult> CreateReportType([FromBody] ReportTypeResource reportTypeResource)
        {
            var transform = new ReportTypeTransform();
            var reportType = transform.ToEntity(reportTypeResource);

            await _commandService.AddAsync(reportType);
            await _commandService.CompleteAsync();
            return Ok();
        }
    }
}