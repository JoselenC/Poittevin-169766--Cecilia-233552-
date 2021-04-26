using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [Route("api/Patient")]
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

        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            patientService.AddPatient(patient);
            return Created($"api/patient/{patient.Name}", patient);
        }

        [HttpPost]
        public CreatedResult ScheduleMeeting(Patient patient, Problematic problematic)
        {
            Meeting meeting = patientService.ScheduleNewMeeting(patient, problematic);
            return Created($"api/patient/schedule", meeting);
        }
    }
}