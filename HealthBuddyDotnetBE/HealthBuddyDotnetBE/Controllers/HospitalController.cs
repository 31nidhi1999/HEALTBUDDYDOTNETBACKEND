using HealthBuddyDotnetBE.RequestDto;
using HealthBuddyDotnetBE.ResponseDto;
using HealthBuddyDotnetBE.Repositories;
using HealthBuddyDotnetBE.Services;
using Microsoft.AspNetCore.Mvc;
//using Org.BouncyCastle.Ocsp;
using HealthBuddyDotnetBE.Services.Declaration;
using HealthBuddyDotnetBE.RequestDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthBuddyDotnetBE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService service;

        public HospitalController(IHospitalService service)
        {
            this.service = service;
        }
        // GET: api/<HospitalController>
        [HttpGet]
        public IActionResult Get()
        {
            var hospitals = service.GetAllHospitals();
            if (hospitals == null)
                return NotFound(new { Message = $"No hospitals found " });

            return Ok(hospitals);
        }
        [HttpGet("active")]
        public IActionResult GetActive()
        {
            
            List<HospitalResDto> hospitals = service.GetActiveHospitals();
            return Ok(hospitals);
        }


        // GET api/<HospitalController>/5
        /*[HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var doctors = service.getActiveHospitals();
            if (doctors == null)
                return NotFound(new { Message = $"No doctor found " });

            return Ok(doctors);
        }*/

        // POST api/<HospitalController>
        [HttpPost]
        public string Post([FromBody] HospitalReqDto hospitalDto)
        {
            return service.AddHospital(hospitalDto).Message;
        }

        // PUT api/<HospitalController>/5
        [HttpPut("{id}")]
        public string Put(long id, [FromBody] HospitalReqDto hospitalDto)
        {
            return service.UpdateHospital(id, hospitalDto).Message;
        }

        // DELETE api/<HospitalController>/5
        [HttpDelete("{hospId}/doctor/{doctorId}")]
        /*public string RemoveDoctor(long hospId, long doctorId)
        {
            return service.removeDoctor(hospId, doctorId);
        }*/

        [HttpPost("{hospid}/doctor/{doctorId}")]
        public string addDocInHosp(long hospid, long doctorId)
        {
            return service.AddDoctor(hospid, doctorId).Message;
        }

        [HttpPatch("activate/{hospId}")]
        public string activateHospital(long hospId)
        {
            return service.ActivateHospital(hospId);
        }
        [HttpPatch("inActivate/{hospId}")]
        public string inActivateHospital(long hospId)
        {
            return service.InActivateHospital(hospId);
        }
    }
}
