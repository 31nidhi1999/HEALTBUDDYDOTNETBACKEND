using HealthBuddyDotnetBE.RequestDto;
using HealthBuddyDotnetBE.ResponseDto;
using HealthBuddyDotnetBE.Services;
using HealthBuddyDotnetBE.ResponseDto;
using HealthBuddyDotnetBE.Services.Declaration;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthBuddyDotnetBE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private IAppointmentService _appointementService;

        public AppointmentController(IAppointmentService appointementService)
        {
            _appointementService = appointementService;
        }

        // GET: api/<AppointementController>
        [HttpGet]
        public List<AppointmentResDto> Get()
        {
            return _appointementService.GetAllAppointments();
        }

        // GET api/<AppointementController>/5
        [HttpGet("{id}")]
        /*public AppointmentResDto Get(long id)
        {
            return _appointementService.getAppointment(id);
        }*/

        [HttpGet("patient/{patientId}")]
        public List<AppointmentResDto> GetByPatient(long patientId)
        {
            return _appointementService.GetAppointmentsByPatientId(patientId);
        }

        [HttpGet("doctor/{doctorId}")]
        public List<AppointmentResDto> GetByDoctor(long doctorId)
        {
            return _appointementService.GetAppointmentsByDoctorId(doctorId);
        }

        [HttpGet("hosp/{hospId}")]
        public List<AppointmentResDto> GetByHospital(long hospId)
        {
            return _appointementService.GetAppointmentsByHospitalId(hospId);
        }

        // POST api/<AppointementController>
        [HttpPost]
        public AppointmentResDto Post([FromBody] AppointmentReqDto appointmentReqDto)
        {
            long id = appointmentReqDto.DoctorId;
            return _appointementService.BookAppointment(appointmentReqDto);
        }

        // PUT api/<AppointementController>/5
        [HttpPatch("cancle/{appointId}")]
        public string cancleAppointment(long appointId)
        {
            return _appointementService.CancelAppointment(appointId);
        }

        [HttpPatch("complete/{appointId}")]
        public string completeAppointment(long appointId)
        {
            return _appointementService.CompleteAppointment(appointId);
        }
    }
}
