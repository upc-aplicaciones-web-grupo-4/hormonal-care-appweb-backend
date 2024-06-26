﻿using System.Net.Mime;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Commands;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Queries;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;
using AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST;

    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class DoctorController(IDoctorCommandService doctorCommandService, IDoctorQueryService doctorQueryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorResource resource)
        {
            var createDoctorCommand = CreateDoctorCommandFromResourceAssembler.ToCommandFromResource(resource);
            var doctor = await doctorCommandService.Handle(createDoctorCommand);
            if (doctor is null) return BadRequest();
            var doctorResource = DoctorResourceFromEntityAssembler.ToResourceFromEntity(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { doctorId = doctorResource.Id }, doctorResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var getAllDoctorsQuery = new GetAllDoctorsQuery();
            var doctors = await doctorQueryService.Handle(getAllDoctorsQuery);
            var doctorResources = doctors.Select(DoctorResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(doctorResources);
        }

        
        [HttpGet("{doctorId:int}")]
        public async Task<IActionResult> GetDoctorById(int doctorId)
        {
            var getDoctorByIdQuery = new GetDoctorByIdQuery(doctorId);
            var doctor = await doctorQueryService.Handle(getDoctorByIdQuery);
            if (doctor == null) return NotFound();
            var doctorResource = DoctorResourceFromEntityAssembler.ToResourceFromEntity(doctor);
            return Ok(doctorResource);
        }

        [HttpPut("{doctorId:int}/appointmentfee")]
        public async Task<IActionResult> UpdateDoctorAppointmentFee(int doctorId, UpdateDoctorAppointmentFeeRecourse resource)
        {
            var updateDoctorAppointmentFeeCommand = UpdateDoctorAppointmentFeeCommandFromResourceAssembler.ToCommandFromResource(doctorId, resource);
            var updatedDoctor = await doctorCommandService.Handle(updateDoctorAppointmentFeeCommand);
            if (updatedDoctor == null) return BadRequest();
            var updatedDoctorResource = DoctorResourceFromEntityAssembler.ToResourceFromEntity(updatedDoctor);
            return Ok(updatedDoctorResource);
        }

        [HttpPut("{doctorId:int}/subscriptionid")]
        public async Task<IActionResult> UpdateDoctorSubscriptionId(int doctorId, UpdateDoctorSubscriptionIdResource resource)
        {
            var updateDoctorSubscriptionIdCommand = UpdateDoctorSubscriptionIdCommandFromResourceAssembler.ToCommandFromResource(doctorId, resource);
            var updatedDoctor = await doctorCommandService.Handle(updateDoctorSubscriptionIdCommand);
            if (updatedDoctor == null) return BadRequest();
            var updatedDoctorResource = DoctorResourceFromEntityAssembler.ToResourceFromEntity(updatedDoctor);
            return Ok(updatedDoctorResource);
        }
    }
