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
public class ReasonOfConsultationController(IReasonOfConsultationCommandService reasonOfConsultationCommandService, IReasonOfConsultationQueryService reasonOfConsultationQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateReasonOfConsultation(CreateReasonOfConsultationResource resource)
    {
        var createReasonOfConsultationCommand = CreateReasonOfConsultationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var reasonOfConsultation = await reasonOfConsultationCommandService.Handle(createReasonOfConsultationCommand);
        if (reasonOfConsultation is null) return BadRequest();
        var reasonOfConsultationResource = ReasonOfConsultationResourceFromEntityAssembler.ToResourceFromEntity(reasonOfConsultation);
        return CreatedAtAction(nameof(GetReasonOfConsultationById), new {reasonOfConsultationId = reasonOfConsultationResource.Id}, reasonOfConsultationResource);
    }
    
    [HttpGet("{reasonOfConsultationId:int}")]
    public async Task<IActionResult> GetReasonOfConsultationById(int reasonOfConsultationId)
    {
        var getReasonOfConsultationByIdQuery = new GetReasonOfConsultationByIdQuery(reasonOfConsultationId);
        var reasonOfConsultation = await reasonOfConsultationQueryService.Handle(getReasonOfConsultationByIdQuery);
        if (reasonOfConsultation == null) return NotFound();
        var reasonOfConsultationResource = ReasonOfConsultationResourceFromEntityAssembler.ToResourceFromEntity(reasonOfConsultation);
        return Ok(reasonOfConsultationResource);
    }
    
    [HttpPut("{reasonOfConsultationId:int}")]
    public async Task<IActionResult> UpdateReasonOfConsultation(int reasonOfConsultationId, UpdateReasonOfConsultationResource resource)
    {
        var updateReasonOfConsultationCommand = UpdateReasonOfConsultationCommandFromResourceAssembler.ToCommandFromResource(reasonOfConsultationId, resource);
        var updatedReasonOfConsultation = await reasonOfConsultationCommandService.Handle(updateReasonOfConsultationCommand);
        if (updatedReasonOfConsultation == null) return BadRequest();
        var updatedReasonOfConsultationResource = ReasonOfConsultationResourceFromEntityAssembler.ToResourceFromEntity(updatedReasonOfConsultation);
        return Ok(updatedReasonOfConsultationResource);
    }
}

