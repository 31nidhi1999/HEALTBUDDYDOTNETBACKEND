using Health.Entity;

namespace HealthBuddyDotnetBE.Repositories.Declaration
{
    public interface IAppointmentRepository
    {
        void AddAppointment();
        void UpdateAppointment();
        void DeleteAppointment();
        Appointment GetAppointmentById();
        List<Appointment> GetAllAppointments();

    }
}
