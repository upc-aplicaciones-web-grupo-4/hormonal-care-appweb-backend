using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;

namespace AppWeb.HormonalCare.API.MedicalRecord
{
    [ApiController]
    [Route("/api/v1/diagnostic")]
    public class DiagnosticController : ControllerBase
    {
        private readonly iDiagnosticCommandService _commandService;
        private readonly IDiagnosticQueryService _queryService;

        public DiagnosticController(iDiagnosticCommandService commandService, IDiagnosticQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        // Método GET
        [HttpGet]
        public async Task<IActionResult> GetDiagnostics()
        {
            var diagnostics = await _queryService.GetAllDiagnosticsAsync();
            if (diagnostics == null)
            {
                return NotFound();
            }

            var transform = new DiagnosticTransform();
            var diagnosticResources = diagnostics.Select(transform.ToResource);

            return Ok(diagnosticResources);
        }

        // Método POST
        [HttpPost]
        public async Task<IActionResult> CreateDiagnostic([FromBody] DiagnosticResource diagnosticResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transform = new DiagnosticTransform();

            var diagnostic = transform.ToEntity(diagnosticResource);

            // Create the Diagnostic entity
            var result = await _commandService.CreateDiagnosticAsync(diagnostic);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Diagnostic);
        }
    }
}