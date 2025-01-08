using System.Collections.Generic;
using HealthBuddyDotnetBE.ResponseDto;
using HealthBuddyDotnetBE.RequestDto;
using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.Services;
using Microsoft.AspNetCore.Mvc;
using HealthBuddyDotnetBE.Services.Declaration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthBuddyDotnetBE.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService service;
        public DoctorController(IDoctorService service)
        {
            this.service = service;
        }
        // GET: api/<DoctorController>
        [HttpGet]
        public IActionResult Get()
        {
            var doctors = service.GetAllDoctors();
            if (doctors == null)
                return NotFound(new { Message = $"No doctor found " });

            return Ok(doctors);
        }

        [HttpGet("active")]
        public IActionResult GetActive()
        {
            List<DoctorResDto> doctors = service.GetAllActiveDoctors();
            if (doctors == null)
                return NotFound(new { Message = $"No doctor found " });

            return Ok(doctors);
        }

        [HttpGet("hosp/{hospId}")]
        public IActionResult GetDoctorsByHosp(long hospId)
        {
            List<DoctorResDto> doctors = service.GetDoctorsByHospital(hospId);
            
            return Ok(doctors);
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var doctor = service.GetDoctorById(id);

            if (doctor == null)
                return NotFound(new { Message = $"No doctor found with ID {id}" });

            return Ok(doctor);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public string Post([FromBody] DoctorReqDto doctorDto)
        {
            return service.AddDoctor(doctorDto).Message;

        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] DoctorReqDto doctorDto)
        {
            return service.UpdateDoctor(id, doctorDto);
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPatch("inactivate/{doctorId}")]
        public ApiResponse InActivateDoctor(int doctorId)
        {
            return service.InactivateDoctor(doctorId);
        }
        [HttpPatch("activate/{doctorId}")]
        public ApiResponse ActivateDoctor(int doctorId)
        {
            return service.ActivateDoctor(doctorId);
        }
    }
}
