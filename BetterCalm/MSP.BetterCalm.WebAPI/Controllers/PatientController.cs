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
            return Created($"/patient/{patient.Name}", patient);
        }
    }
}