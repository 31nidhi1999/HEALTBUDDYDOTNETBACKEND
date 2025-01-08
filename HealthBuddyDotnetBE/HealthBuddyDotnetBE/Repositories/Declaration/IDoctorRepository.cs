using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.ResponseDto;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace HealthBuddyDotnetBE.Repositories.Declaration
{
    public interface IDoctorRepository
    {
        long AddDoctor(Doctor doctor);
        //ApiResponse DeleteDoctor(long doctId);
        void UpdateDoctor(Doctor doctor);
        Doctor GetDoctorById(long doctId);
        List<Doctor> GetAllDoctors();

        Doctor GetDoctorByEmail(string email);

        List<Doctor> GetDoctorsByHospitalId(long hospId);
    }
}
