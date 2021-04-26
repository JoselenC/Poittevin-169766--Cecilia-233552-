using System;
using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class PatientService : IPatientService
    {
        private ManagerPatientRepository patientRepository;
        private ManagerPsychologistRepository psychologistRepository;

        public PatientService(ManagerPatientRepository vRepository, ManagerPsychologistRepository vPsyRepo)
        {
            patientRepository = vRepository;
            psychologistRepository = vPsyRepo;
        }

        public List<Patient> GetPatients()
        {
            return patientRepository.Patients.Get();
        }

        public void AddPatient(Patient patient)
        {
            patientRepository.Patients.Add(patient);
        }

        public Meeting ScheduleNewMeeting(Patient patient, Problematic problematic)
        {
            Psychologist psychologist =
                psychologistRepository.Psychologists.Find(
                    x => x.Problematics.Contains(problematic) && x.GetDayForNextMeetingOnWeek(DateTime.Now) != null
                );
            
            // TODO: ver si no se puede evitar hacer este if
            if (!(psychologist is null))
            {
                DateTime auxDate = (DateTime) psychologist.GetDayForNextMeetingOnWeek(DateTime.Now);
                DateTime date = new DateTime(auxDate.Year, auxDate.Month, auxDate.Day, 0, 0, 0);
                Meeting meeting = new Meeting()
                {
                    DateTime = date,
                    Patient = patient,
                    Psychologist = psychologist
                };
                patient.Meetings.Add(meeting);
                patientRepository.Patients.Update(patient, patient);
                return meeting;
            }
            throw new PsychologistNotFound();
            
        }
    }
}