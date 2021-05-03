using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface IPatientService
    {
        List<Patient> GetPatients();

        void SetPatient(Patient patient);
        Meeting ScheduleNewMeeting(Patient patient, Problematic problematic);
    }
}