using HealthBuddyDotnetBE.Entities;

namespace HealthBuddyDotnetBE.Repositories.Declaration
{
    public interface IPatientRepository
    {
        void AddPatient();
        void UpdatePatient();
        void DeletePatient();
        Patient GetPatientById();
        List<Patient> GetAllPatients();

        Patient GetPatientByEmail(string email);
    }
}
