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
public class TypeExamController(ITypeExamCommandService typeExamCommandService, ITypeExamQueryService typeExamQueryService) : ControllerBase
{

    
    [HttpPost]
    public async Task<IActionResult> CreateTypeExam(CreateTypeExamResource resource)
    {
        var createTypeExamCommand = CreateTypeExamCommandFromResourceAssembler.ToCommandFromResource(resource);
        var typeExam = await typeExamCommandService.Handle(createTypeExamCommand);
        if (typeExam is null) return BadRequest();
        var typeExamResource = TypeExamResourceFromEntityAssembler.ToResourceFromEntity(typeExam);
        return CreatedAtAction(nameof(GetTypeExamById), new {typeExamId = typeExamResource.Id}, typeExamResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTypeExams()
    {
        var getAllTypesExamsQuery = new GetAllTypesExamsQuery();
        var typeExams = await typeExamQueryService.Handle(getAllTypesExamsQuery);
        var typeExamResources = typeExams.Select(TypeExamResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(typeExamResources);
    }

    [HttpGet("{typeExamId:int}")]
    public async Task<IActionResult> GetTypeExamById(int typeExamId)
    {
        var getTypeExamByIdQuery = new GetTypeExamByIdQuery(typeExamId);
        var typeExam = await typeExamQueryService.Handle(getTypeExamByIdQuery);
        if (typeExam == null) return NotFound();
        var typeExamResource = TypeExamResourceFromEntityAssembler.ToResourceFromEntity(typeExam);
        return Ok(typeExamResource);
    }
    
}