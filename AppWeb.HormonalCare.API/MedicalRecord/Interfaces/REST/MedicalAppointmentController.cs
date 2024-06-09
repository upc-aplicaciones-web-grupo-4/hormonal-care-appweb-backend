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
public class MedicalAppointmentController (IMedicalAppointmentCommandService medicalAppointmentCommandService, IMedicalAppointmentQueryService medicalAppointmentQueryService): ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> CreateMedicalAppointment(CreateMedicalAppointmentResource resource)
    {
        if (resource == null)
        {
            return BadRequest("Invalid data.");
        }

        var createMedicalAppointmentCommand = CreateMedicalAppointmentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var medicalAppointment = await medicalAppointmentCommandService.Handle(createMedicalAppointmentCommand);
        if (medicalAppointment is null) return BadRequest();
        var medicalAppointmentResource = MedicalAppointmentResourceFromEntityAssembler.ToResourceFromEntity(medicalAppointment);
        return CreatedAtAction(nameof(GetMedicalAppointmentById), new {medicalAppointmentId = medicalAppointmentResource.Id}, medicalAppointmentResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMedicalAppointments()
    {
        var getAllMedicalAppointmentsQuery = new GetAllMedicalAppointmentQuery();
        var medicalAppointments = await medicalAppointmentQueryService.Handle(getAllMedicalAppointmentsQuery);
        var medicalAppointmentsResource = medicalAppointments.Select(MedicalAppointmentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(medicalAppointmentsResource);
    }

    [HttpGet("{medicalAppointmentId:int}")]
    public async Task<IActionResult> GetMedicalAppointmentById(int medicalAppointmentId)
    {
        var getMedicalAppointmentByIdQuery = new GetMedicalAppointmentByIdQuery(medicalAppointmentId);
        var medicalAppointment = await medicalAppointmentQueryService.Handle(getMedicalAppointmentByIdQuery);
        if (medicalAppointment == null) return NotFound();
        var medicalAppointmentResource = MedicalAppointmentResourceFromEntityAssembler.ToResourceFromEntity(medicalAppointment);
        return Ok(medicalAppointmentResource);
    }

    [HttpPut("{medicalAppointmentId:int}")]
    public async Task<IActionResult> UpdateMedicalAppointment(int medicalAppointmentId, UpdateMedicalAppointmentResource resource)
    {
        if (resource == null)
        {
            return BadRequest("Invalid data.");
        }

        var updateMedicalAppointmentCommand = UpdateMedicalAppointmentCommandFromResourceAssembler.ToCommandFromResource(medicalAppointmentId, resource);
        var updatedMedicalAppointment = await medicalAppointmentCommandService.Handle(updateMedicalAppointmentCommand);
        if (updatedMedicalAppointment == null) return BadRequest();
        var updatedMedicalAppointmentResource = MedicalAppointmentResourceFromEntityAssembler.ToResourceFromEntity(updatedMedicalAppointment);
        return Ok(updatedMedicalAppointmentResource);
    }
}