using HealthBuddyDotnetBE.Services;
using HealthBuddyDotnetBE.Services.Declaration;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthBuddyDotnetBE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private ITimeSlotService timeSlotService;
        public TimeSlotController(ITimeSlotService timeSlotService)
        {
            this.timeSlotService = timeSlotService;
        }

        [HttpGet("available/doctor/{doctorId}/date/{date}")]
        public List<TimeSpan> Get(long doctorId, string date)
        {
            TimeSpan start = TimeSpan.Parse("10:00:00");
            TimeSpan end = TimeSpan.Parse("16:00:00");
            return timeSlotService.GetAvailableTimeSlotsForDay(doctorId, date, start, end);
        }
    }
}
