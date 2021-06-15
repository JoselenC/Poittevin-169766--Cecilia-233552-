using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.BusinessLogicInterface;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [FilterExceptions]
    [Route("api/[controller]")]
    public class PatientController: ControllerBase
    {
        private IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Patient> patientes = patientService.GetPatients();
            return Ok(patientes);
        }

        [HttpGet("{patientId}")]
        public IActionResult GetPatientById(int patientId)
        {
            Patient patient = patientService.GetPatientsById(patientId);
            return Ok(patient);
        }
        
        [HttpPost("schedule")]
        public IActionResult ScheduleMeeting([FromBody] ScheduleMeetingDto scheduleMeetingDto)
        {
            Meeting meeting = patientService.ScheduleNewMeeting(scheduleMeetingDto.Patient, 
                scheduleMeetingDto.Problematic);
            return Created($"api/patient/schedule", meeting);
        }
        
        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            Patient returnPatient = patientService.SetPatient(patient);
            return Created($"api/patient/{returnPatient.Name}", returnPatient);
        }

        
        [HttpDelete("{patientId}")]
        public OkObjectResult DeletePatientById(int patientId)
        {
            patientService.DeletePatientById(patientId);
            return Ok("Entity removed");
        }
        
        [HttpPut("{patientId}")]
        public IActionResult UpdatePatient(
            [FromBody] Patient patient, 
            [FromRoute] int patientId)
        {
            Patient updatedPatient = patientService.UpdatePatient(patient, patientId);
            return Ok(updatedPatient);
        }
    }
}