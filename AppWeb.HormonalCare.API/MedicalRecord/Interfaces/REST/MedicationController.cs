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
public class MedicationController(
    IMedicationCommandService medicationCommandService,
    IMedicationQueryService medicationQueryService,
    IMedicationTypeCommandService medicationTypeCommandService,
    IMedicationTypeQueryService medicationTypeQueryService,
    IPrescriptionCommandService prescriptionCommandService,
    IPrescriptionQueryService prescriptionQueryService) : ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> CreateMedication(CreateMedicationResource resource)
    {
        var createMedicationCommand = CreateMedicationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var medication = await medicationCommandService.Handle(createMedicationCommand);
        if (medication is null) return BadRequest();
        var medicationResource = MedicationResourceFromEntityAssembler.ToResourceFromEntity(medication);
        return CreatedAtAction(nameof(GetMedicationById), new { medicationId = medicationResource.Id }, medicationResource);
    }

    [HttpGet("{medicationId:int}")]
    public async Task<IActionResult> GetMedicationById(int medicationId)
    {
        var getMedicationByIdQuery = new GetMedicationByIdQuery(medicationId);
        var medication = await medicationQueryService.Handle(getMedicationByIdQuery);
        if (medication == null) return NotFound();
        var medicationResource = MedicationResourceFromEntityAssembler.ToResourceFromEntity(medication);
        return Ok(medicationResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMedications()
    {
        var getAllMedicationsQuery = new GetAllMedicationsQuery();
        var medications = await medicationQueryService.Handle(getAllMedicationsQuery);
        var medicationResources = medications.Select(MedicationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(medicationResources);
    }

    [HttpPost("prescriptions")]
public async Task<IActionResult> CreatePrescription(CreatePrescriptionResource resource)
{
    var createPrescriptionCommand = CreatePrescriptionCommandFromResourceAssembler.ToCommandFromResource(resource);
    var prescription = await prescriptionCommandService.Handle(createPrescriptionCommand);
    if (prescription is null) return BadRequest();
    var prescriptionResource = PrescriptionResourceFromEntityAssembler.ToResourceFromEntity(prescription);
    return CreatedAtAction(nameof(GetPrescriptionById), new { prescriptionId = prescriptionResource.Id }, prescriptionResource);
}

[HttpGet("prescriptions/{prescriptionId:int}")]
public async Task<IActionResult> GetPrescriptionById(int prescriptionId)
{
    var getPrescriptionByIdQuery = new GetPrescriptionByIdQuery(prescriptionId);
    var prescription = await prescriptionQueryService.Handle(getPrescriptionByIdQuery);
    if (prescription == null) return NotFound();
    var prescriptionResource = PrescriptionResourceFromEntityAssembler.ToResourceFromEntity(prescription);
    return Ok(prescriptionResource);
}


[HttpPost("medication-types")]
public async Task<IActionResult> CreateMedicationType(CreateMedicationTypeResource resource)
{
    var createMedicationTypeCommand = CreateMedicationTypeCommandFromResourceAssembler.ToCommandFromResource(resource);
    var medicationType = await medicationTypeCommandService.Handle(createMedicationTypeCommand);
    if (medicationType is null) return BadRequest();
    var medicationTypeResource = MedicationTypeResourceFromEntityAssembler.ToResourceFromEntity(medicationType);
    return CreatedAtAction(nameof(GetMedicationTypeById), new { medicationTypeId = medicationTypeResource.Id }, medicationTypeResource);
}

[HttpGet("medication-types/{medicationTypeId:int}")]
public async Task<IActionResult> GetMedicationTypeById(int medicationTypeId)
{
    var getMedicationTypeByIdQuery = new GetMedicationTypeByIdQuery(medicationTypeId);
    var medicationType = await medicationTypeQueryService.Handle(getMedicationTypeByIdQuery);
    if (medicationType == null) return NotFound();
    var medicationTypeResource = MedicationTypeResourceFromEntityAssembler.ToResourceFromEntity(medicationType);
    return Ok(medicationTypeResource);
}

}