using HealthBuddyDotnetBE.Contexts;
using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.Repositories.Declaration;

namespace HealthBuddyDotnetBE.Repositories.Implementation
{
    public class PatientRepository:IPatientRepository
    {
        public HealhBuddyContext healhBuddyContext;

        public PatientRepository(HealhBuddyContext healhBuddyContext)
        {
            this.healhBuddyContext = healhBuddyContext;
        }

        public long AddPatient(Patient patient)
        {
            healhBuddyContext.Patients.Add(patient);
            healhBuddyContext.SaveChanges();
            return patient.Id;
        }

        public void UpdatePatient(Patient patient)
        {
            healhBuddyContext.Patients.Update(patient);
            healhBuddyContext.SaveChanges();
        }

        public void DeletePatient(long patientId)
        {
            healhBuddyContext.Patients.Remove(healhBuddyContext.Patients.Find(patientId));
            healhBuddyContext.SaveChanges();
        }

        public Patient GetPatientById(long patientId)
        {
            return healhBuddyContext.Patients.Find(patientId);
        }

        public List<Patient> GetAllPatients()
        {
            return healhBuddyContext.Patients.ToList();
        }

        public Patient GetPatientByEmail(string email)
        {
            return healhBuddyContext.Patients.FirstOrDefault(p => p.Email == email);
        }

    }
}
