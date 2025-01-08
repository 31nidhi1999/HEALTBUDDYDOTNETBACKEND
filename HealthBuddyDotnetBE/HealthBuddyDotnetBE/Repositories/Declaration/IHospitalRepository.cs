using Health.Entity;

namespace HealthBuddyDotnetBE.Repositories.Declaration
{
    public interface IHospitalRepository
    {
        long AddHospital(Hospital hospital);
        void UpdateHospital(Hospital hospital);
        void DeleteHospital(long HospId);
        Hospital GetHospitalById(long HospId);
        List<Hospital> GetAllHospitals();

    
    }
}
