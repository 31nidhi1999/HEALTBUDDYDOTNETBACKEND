using System;
using System.Collections.Generic;

namespace HealthBuddyDotnetBE.Services.Declaration
{
    public interface ITimeSlotService
    {
        List<TimeSpan> GetAvailableTimeSlotsForDay(long doctorId, string date, TimeSpan startTime, TimeSpan endTime);
    }
}
