using Health.Entity;
using HealthBuddyDotnetBE.Contexts;
using HealthBuddyDotnetBE.Repositories.Declaration;

namespace HealthBuddyDotnetBE.Repositories.Implementation
{
    public class HopitalRepository: IHospitalRepository
    {
        public HealhBuddyContext healhBuddyContext;

        public HopitalRepository(HealhBuddyContext healhBuddyContext)
        {
            this.healhBuddyContext = healhBuddyContext;
        }

        public long AddHospital(Hospital hospital)
        {
            healhBuddyContext.Hospitals.Add(hospital);
            healhBuddyContext.SaveChanges();
            return hospital.Id;
        }
        public void UpdateHospital(Hospital hospital)
        {
            healhBuddyContext.Hospitals.Update(hospital);
            healhBuddyContext.SaveChanges();
        }

        public void DeleteHospital(long hospId)
        {
            healhBuddyContext.Hospitals.Remove(healhBuddyContext.Hospitals.Find(hospId));
            healhBuddyContext.SaveChanges();
        }

        public Hospital GetHospitalById(long hospId)
        {
            return healhBuddyContext.Hospitals.Find(hospId);
        }

        public List<Hospital> GetAllHospitals()
        {
            return healhBuddyContext.Hospitals.ToList();
        }
        
       

    }
}
