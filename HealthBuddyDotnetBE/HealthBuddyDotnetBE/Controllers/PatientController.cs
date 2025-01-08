using HealthBuddyDotnetBE.RequestDto;
using HealthBuddyDotnetBE.RequestDto;//.Health.ReqDto;
using HealthBuddyDotnetBE.ResponseDto;
using HealthBuddyDotnetBE.Services;
using HealthBuddyDotnetBE.Services.Declaration;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthBuddyDotnetBE.Controllers
{


    [Route("[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public IActionResult Get()
        {
            var patients = patientService.GetAllPatients();
            if (patients == null)
                return NotFound(new { Message = $"No patient found " });

            return Ok(patients);
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var patient = patientService.GetPatientById(id);
            if (patient == null)
                return NotFound(new { Message = $"No patient found " });

            return Ok(patient);
        }

        // POST api/<PatientController>
        [HttpPost]
        public string Post([FromBody] PatientReqDto patientDto)
        {
            return patientService.AddPatient(patientDto).Message;
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        /*public string Put(int id, [FromBody] PatientReqDto patientDto)
        {
            return patientService.updatePatient(id, patientDto);
        }*/

        // DELETE api/<PatientController>/5
        [HttpPatch("activate/{id}")]
        public string activatePatient(int id)
        {
            return patientService.ActivatePatient(id).Message;
        }

        [HttpPatch("inActivate/{id}")]
        public string inActivatePatient(int id)
        {
            return patientService.InactivatePatient(id).Message;
        }
    }
}
