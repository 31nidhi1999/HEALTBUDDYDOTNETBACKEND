using Health.Entity;
using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.ResponseDto;
using Microsoft.AspNetCore.Components;
using NodaTime;

namespace HealthBuddyDotnetBE.Repositories.Declaration
{
    public interface IAppointmentRepository
    {
        
        long AddAppointment(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(Appointment appointment);

        List<Appointment> GetAllAppointment();

        Appointment GetAppointmentById(long appointmentId);

        List<Appointment> FindByHopital(Hospital hospital);
        List<Appointment> FindByDoctor(Doctor doctor);

        List<Appointment> FindByPatient(Patient patient);

        List<Appointment> findBookedTimeSlotByDoctorandDate(long doctorId, DateTime appointmentDate);

    }
}
