using Health.Entity;

namespace HealthBuddyDotnetBE.Repositories.Declaration
{
    public interface IHospitalRepository
    {
        void AddHospital();
        void UpdateHospital();
        void DeleteHospital();
        Hospital GetHospitalById();
        List<Hospital> GetAllHospitals();

    
    }
}
