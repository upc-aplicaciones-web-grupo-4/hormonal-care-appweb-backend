using System.Net.Mime;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.ValuesObjects;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PatientController(IPatientCommandService patientCommandService, IPatientQueryService patientQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePatient(CreatePatientResource resource)
    {
        var createPatientCommand = CreatePatientCommandFromResourceAssembler.ToCommandFromResource(resource);
        var patient = await patientCommandService.Handle(createPatientCommand);
        if (patient is null) return BadRequest();
        var getPatientByPatientRecordIdQuery = new GetPatientByPatientRecordIdQuery(patient.RecordId);
        var patientByPatientRecordId = await patientQueryService.Handle(getPatientByPatientRecordIdQuery);
        if (patientByPatientRecordId == null) return BadRequest();
        var patientResource = PatientResourceFromEntityAssembler.ToResourceFromEntity(patientByPatientRecordId);
        return CreatedAtAction(nameof(GetPatientById), new { patientId = patientResource.Id }, patientResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        var getAllPatientsQuery = new GetAllPatientsQuery();
        var patients = await patientQueryService.Handle(getAllPatientsQuery);
        var patientResources = patients.Select(PatientResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(patientResources);
    }
    
    [HttpGet("{patientId:int}")]
    public async Task<IActionResult> GetPatientById(int patientId)
    {
        var getPatientByIdQuery = new GetPatientByIdQuery(patientId);
        var patient = await patientQueryService.Handle(getPatientByIdQuery);
        if (patient == null) return NotFound();
        var patientResource = PatientResourceFromEntityAssembler.ToResourceFromEntity(patient);
        return Ok(patientResource);
    }
    
    [HttpGet("{patientRecordId}")]
    public async Task<IActionResult> GetPatientByPatientRecordId(string recordId)
    {
        var patientRecordId = new PatientRecord(recordId);
        var getPatientByPatientRecordIdQuery = new GetPatientByPatientRecordIdQuery(patientRecordId.RecordId);
        var patient = await patientQueryService.Handle(getPatientByPatientRecordIdQuery);
        if (patient == null)
        {
            return NotFound();
        }
        var patientResource = PatientResourceFromEntityAssembler.ToResourceFromEntity(patient);
        return Ok(patientResource);
    }
    
    
    
    [HttpPut("{patientId:int}")]
    public async Task<IActionResult> UpdatePatient(int patientId, UpdatePatientResource resource)
    {
        if (resource == null )
        {
            return BadRequest("Invalid data.");
        }
        
        var updatePatientCommand = UpdatePatientCommandFromResourceAssembler.ToCommandFromResource(patientId, resource);
        var updatedPatient = await patientCommandService.Handle(updatePatientCommand);
        if (updatedPatient == null) return BadRequest();
        var updatedPatientResource = PatientResourceFromEntityAssembler.ToResourceFromEntity(updatedPatient);
        return Ok(updatedPatientResource);
    }
    
}




