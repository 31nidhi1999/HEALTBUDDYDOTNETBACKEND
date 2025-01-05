using HealthBuddyDotnetBE.Entities;

namespace HealthBuddyDotnetBE.Repositories.Declaration
{
    public interface IDoctorRepository
    {
        void AddDoctor(Doctor doctor);
        void DeleteDoctor(long doctId);
        void UpdateDoctor(Doctor doctor);
        Doctor GetDoctorById(long doctId);
        List<Doctor> GetAllDoctors();

        Doctor GetDoctorByEmail(string email);

        ISet<Doctor> GetDoctorsByHospitalId(long hospId);
    }
}
