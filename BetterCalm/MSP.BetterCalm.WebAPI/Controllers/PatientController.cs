using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
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
            patientService.AddPatient(patient);
            return Created($"api/patient/{patient.Name}", patient);
        }

    }
}