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
public class MedicalExamController(IMedicalExamCommandService medicalExamCommandService, IMedicalExamQueryService medicalExamQueryService) : ControllerBase
{
    
    
    [HttpPost]
    public async Task<IActionResult> CreateMedicalExam(CreateMedicalExamResource resource)
    {
        if (resource == null || resource.TypeExamIdentifier <= 0)
        {
            return BadRequest("Invalid data.");
        }

        
        var createMedicalExamCommand = CreateMedicalExamCommandFromResourceAssembler.ToCommandFromResource(resource);
        var medicalExam = await medicalExamCommandService.Handle(createMedicalExamCommand);
        if (medicalExam is null) return BadRequest();
        var medicalExamResource = MedicalExamResourceFromEntityAssembler.ToResourceFromEntity(medicalExam);
        return CreatedAtAction(nameof(GetMedicalExamById), new {medicalExamId = medicalExamResource.Id}, medicalExamResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMedicalExams()
    {
        var getAllMedicalsExamsQuery = new GetAllMedicalExamsQuery();
        var medicalExams = await medicalExamQueryService.Handle(getAllMedicalsExamsQuery);
        var medicalExamResources = medicalExams.Select(MedicalExamResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(medicalExamResources);
    }

    [HttpGet("{medicalExamId:int}")]
    public async Task<IActionResult> GetMedicalExamById(int medicalExamId)
    {
        var getMedicalExamByIdQuery = new GetMedicalExamByIdQuery(medicalExamId);
        var medicalExam = await medicalExamQueryService.Handle(getMedicalExamByIdQuery);
        if (medicalExam == null) return NotFound();
        var medicalExamResource = MedicalExamResourceFromEntityAssembler.ToResourceFromEntity(medicalExam);
        return Ok(medicalExamResource);
    }
    
}