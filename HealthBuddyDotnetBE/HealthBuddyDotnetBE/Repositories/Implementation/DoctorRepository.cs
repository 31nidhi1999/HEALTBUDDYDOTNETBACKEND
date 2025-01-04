using HealthBuddyDotnetBE.Contexts;
using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.Repositories.Declaration;

namespace HealthBuddyDotnetBE.Repositories.Implementation
{
    public class DoctorRepository:IDoctorRepository
    {
        public HealhBuddyContext healhBuddyContext;

        public DoctorRepository(HealhBuddyContext healhBuddyContext)
        {
            this.healhBuddyContext = healhBuddyContext;
        }

        public void AddDoctor(Doctor doctor)
        {
            healhBuddyContext.Doctors.Add(doctor);
            healhBuddyContext.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            healhBuddyContext.Doctors.Remove(healhBuddyContext.Doctors.Find(id));
            healhBuddyContext.SaveChanges();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            healhBuddyContext.Doctors.Update(doctor);
            healhBuddyContext.SaveChanges();
        }

        public Doctor GetDoctor(int id)
        {
            return healhBuddyContext.Doctors.Find(id);
        }   
    }
}
