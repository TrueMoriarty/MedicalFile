﻿using DAL.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using DAL.Models;

namespace WebApi.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class DiseasesController(IDiseaseService diseaseService, IUserService userService) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateDiseaseRecord([FromBody] DiseaseRecordModel diseaseRecordModel)
    {
        if (!userService.UserExist(diseaseRecordModel.PatientId, Role.Patient))
            return BadRequest("Patient with this id don't exist");
        if (!userService.UserExist(diseaseRecordModel.DoctorId, Role.Doctor))
            return BadRequest("Doctor with this id don't exist");

        int diseaseId = diseaseService.CreateDiseaseRecord(diseaseRecordModel);
        return Ok(diseaseId);
    }

    [HttpGet]
    public IActionResult GetDiseaseRecords([FromQuery] DiseaseFilterDTO diseaseFilterDTO)
    {

        List<DiseaseRecordDTO> diseaseRecords = diseaseService.GetDiseaseRecords(diseaseFilterDTO).ConvertAll<DiseaseRecordDTO>(DiseaseRecordToDiseaseFilter);

        return Ok(diseaseRecords);
    }
    public DiseaseRecordDTO DiseaseRecordToDiseaseFilter(DiseaseRecord diseaseRecord)
    {
        return new DiseaseRecordDTO
        {
            CreateDate = diseaseRecord.CreatedDate,
            DoctorName = diseaseRecord.Doctor.Name,
            PatientName = diseaseRecord.Patient.Name,
            Symptoms = diseaseRecord.Symptoms,
            Anamnesis = diseaseRecord.Anamnesis,
            Treatment = diseaseRecord.Treatment,
        };
    }
}