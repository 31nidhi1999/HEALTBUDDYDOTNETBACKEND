using Health.Entity;
using HealthBuddyDotnetBE.Contexts;
using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.Repositories.Declaration;
using HealthBuddyDotnetBE.ResponseDto;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using NodaTime;

namespace HealthBuddyDotnetBE.Repositories.Implementation
{
    public class AppointmentRepository:IAppointmentRepository
    {
        private HealhBuddyContext healthBuddyContext;

        public AppointmentRepository(HealhBuddyContext healthBuddyContext)
        {
            this.healthBuddyContext = healthBuddyContext;
        }

        public long AddAppointment(Appointment appointment)
        {
            healthBuddyContext.Appointments.Add(appointment);
            healthBuddyContext.SaveChanges();
            return appointment.Id;

        }

        public void Delete(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> findBookedTimeSlotByDoctorandDate(long doctorId, DateTime appointmentDate)
        {
           return healthBuddyContext.Appointments
                .Where(a=>a.DoctorId == doctorId && a.AppointmentDate == appointmentDate)
                .ToList();
        }

       

        public List<Appointment> FindByDoctor(Doctor doctor)
        {
            healthBuddyContext.Appointments.FirstOrDefault(a => a.Doctor == doctor);
            return null;
        }

        public List<Appointment> FindByHopital(Hospital hospital)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> FindByPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAllAppointment()
        {
            throw new NotImplementedException();
        }

        public Appointment GetAppointmentById(long appointmentId)
        {
            throw new NotImplementedException();
        }

        public void Update(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
