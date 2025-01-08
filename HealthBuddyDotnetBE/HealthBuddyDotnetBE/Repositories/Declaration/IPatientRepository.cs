using HealthBuddyDotnetBE.Entities;

namespace HealthBuddyDotnetBE.Repositories.Declaration
{
    public interface IPatientRepository
    {
        long AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(long id);
        Patient GetPatientById(long patientId);
        List<Patient> GetAllPatients();

        Patient GetPatientByEmail(string email);
    }
}
