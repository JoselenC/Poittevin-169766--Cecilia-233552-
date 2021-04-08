using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class PatientService : IPatientService
    {
        private ManagerPatientRepository repository;

        public PatientService(ManagerPatientRepository vRepository)
        {
            repository = vRepository;
        }

        public List<Patient> GetPatients()
        {
            return repository.Patients.Get();
        }

        public void AddPatient(Patient patient)
        {
            repository.Patients.Add(patient);
        }
    }
}