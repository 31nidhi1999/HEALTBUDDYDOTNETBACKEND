using System.Linq;
using HealthBuddyDotnetBE.Contexts;
using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.Repositories.Declaration;
using Microsoft.AspNetCore.Mvc;

namespace HealthBuddyDotnetBE.Repositories.Implementation
{
    public class DoctorRepository:IDoctorRepository
    {
        public HealhBuddyContext healhBuddyContext;
        public IHospitalRepository hospitalRepository;


        public DoctorRepository(HealhBuddyContext healhBuddyContext, IHospitalRepository hospitalRepository)
        {
            this.healhBuddyContext = healhBuddyContext;
            this.hospitalRepository = hospitalRepository;

        }

    public void AddDoctor(Doctor doctor)
        {
            healhBuddyContext.Doctors.Add(doctor);
            healhBuddyContext.SaveChanges();
        }

        public void DeleteDoctor(long doctId)
        {
            healhBuddyContext.Doctors.Remove(healhBuddyContext.Doctors.Find(doctId));
            healhBuddyContext.SaveChanges();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            //doctor1 is hardcoded for testing
            healhBuddyContext.Doctors.Update(doctor);
            healhBuddyContext.SaveChanges();
        }

        public Doctor GetDoctorById(long doctId)
        {
            return healhBuddyContext.Doctors.Find(doctId);
        } 
        
        public List<Doctor> GetAllDoctors()
        {
            return healhBuddyContext.Doctors.ToList();
        }

        public Doctor GetDoctorByEmail(string email)
        {
            return healhBuddyContext.Doctors.FirstOrDefault(d => d.Email == email);
        }

  


        public ISet<Doctor> GetDoctorsByHospitalId(long hospId)
        {
            return healhBuddyContext.Hospitals
                .Where(h => h.Id == hospId)
                .SelectMany(h => h.Doctors)
                .ToHashSet();
        }


    }
}
