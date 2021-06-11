using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public interface IPatientService
    {
        List<Patient> GetPatients();

        Patient SetPatient(Patient patient);
        Patient GetPatientsById(int patientId);
        Meeting ScheduleNewMeeting(Patient patient, Problematic problematic, double duration);
        void DeletePatientById(int patientId);
        Patient UpdatePatient(Patient newPatient, int patientId);
    }
}