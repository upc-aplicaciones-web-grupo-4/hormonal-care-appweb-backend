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
public class MedicalRecordController (IMedicalRecordCommandService medicalRecordCommandService, IMedicalRecordQueryService medicalRecordQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMedicalRecord(CreateMedicalRecordResource resource)
    {
        var createMedicalRecordCommand = CreateMedicalRecordCommandFromResourceAssembler.ToCommandFromResource(resource);
        var medicalRecord = await medicalRecordCommandService.Handle(createMedicalRecordCommand);
        if (medicalRecord is null) return BadRequest();
        var medicalRecordResource = MedicalRecordResourceFromEntityAssembler.ToResourceFromEntity(medicalRecord);
        return CreatedAtAction(nameof(GetMedicalRecordById), new {medicalRecordId = medicalRecordResource.Id}, medicalRecordResource);
    }
    
    [HttpGet("{medicalRecordId:int}")]
    public async Task<IActionResult> GetMedicalRecordById(int medicalRecordId)
    {
        var getMedicalRecordByIdQuery = new GetMedicalRecordByIdQuery(medicalRecordId);
        var medicalRecord = await medicalRecordQueryService.Handle(getMedicalRecordByIdQuery);
        if (medicalRecord == null) return NotFound();
        var medicalRecordResource = MedicalRecordResourceFromEntityAssembler.ToResourceFromEntity(medicalRecord);
        return Ok(medicalRecordResource);
    }

}
