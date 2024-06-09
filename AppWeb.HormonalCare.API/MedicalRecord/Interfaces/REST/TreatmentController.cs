using System.Net.Mime;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class TreatmentController (ITreatmentCommandService treatmentCommandService, ITreatmentQueryService treatmentQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTreatment(CreateTreatmentResource resource)
    {
        var createTreatmentCommand = CreateTreatmentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var treatment = await treatmentCommandService.Handle(createTreatmentCommand);
        if (treatment is null) return BadRequest();
        var treatmentResource = TreatmentResourceFromEntityAssembler.ToResourceFromEntity(treatment);
        return CreatedAtAction(nameof(GetTreatmentById), new {treatmentId = treatmentResource.Id}, treatmentResource);
    }
    
    [HttpGet("{treatmentId:int}")]
    public async Task<IActionResult> GetTreatmentById(int treatmentId)
    {
        var getTreatmentByIdQuery = new GetTreatmentByIdQuery(treatmentId);
        var treatment = await treatmentQueryService.Handle(getTreatmentByIdQuery);
        if (treatment == null) return NotFound();
        var treatmentResource = TreatmentResourceFromEntityAssembler.ToResourceFromEntity(treatment);
        return Ok(treatmentResource);
    }
    
    [HttpPut("{treatmentId:int}")]
    public async Task<IActionResult> UpdateTreatment(int treatmentId, UpdateTreatmentResource resource)
    {
        var updateTreatmentCommand = UpdateTreatmentCommandFromResourceAssembler.ToCommandFromResource(treatmentId, resource);
        var updatedTreatment = await treatmentCommandService.Handle(updateTreatmentCommand);
        if (updatedTreatment == null) return BadRequest();
        var updatedTreatmentResource = TreatmentResourceFromEntityAssembler.ToResourceFromEntity(updatedTreatment);
        return Ok(updatedTreatmentResource);
    }
}