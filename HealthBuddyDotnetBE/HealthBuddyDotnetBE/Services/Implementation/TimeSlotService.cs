using System;
using System.Collections.Generic;
using System.Linq;
using HealthBuddyDotnetBE.Entities; // Assuming TimeSlot or Appointment entities
using HealthBuddyDotnetBE.Repositories.Declaration;
using HealthBuddyDotnetBE.Services.Declaration;
using HealthBuddyDotnetBE.Utils;
using NodaTime; // Assuming repositories

namespace Health.Service
{
    public class TimeSlotService : ITimeSlotService
    {
        private IAppointmentRepository appointmentRepository;
        public TimeSlotService(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
       
        public List<TimeSpan> GetAvailableTimeSlotsForDay(long doctorId, string date, TimeSpan startTime, TimeSpan endTime)
        {
            List<TimeSpan> allTimeSlots = TimeSlotUtil.GenerateTimeSlots(startTime, endTime);

            
            var bookedTimeSlots = appointmentRepository
           .findBookedTimeSlotByDoctorandDate(doctorId,DateTime.Parse(date))
           .Select(appointment => appointment.TimeSlot.StartTime)
           .ToList();

            // Filter out booked slots
            Console.WriteLine(string.Join(", ", allTimeSlots));
            return allTimeSlots
                .Where(slot => !bookedTimeSlots.Contains(slot))
                .ToList();
        }
    }
}
