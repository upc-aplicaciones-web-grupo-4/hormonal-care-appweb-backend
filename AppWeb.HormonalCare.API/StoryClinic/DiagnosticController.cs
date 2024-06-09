using AppWeb.HormonalCare.API.Publishing.Domain.Services;
using AppWeb.HormonalCare.API.StoryClinic.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppWeb.HormonalCare.API.StoryClinic
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
            return Ok(diagnostics);
        }

        // Método POST
        [HttpPost]
        public async Task<IActionResult> CreateDiagnostic([FromBody] DiagnosticResource diagnosticResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _commandService.CreateDiagnosticAsync(diagnosticResource);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Diagnostic);
        }
    }
}