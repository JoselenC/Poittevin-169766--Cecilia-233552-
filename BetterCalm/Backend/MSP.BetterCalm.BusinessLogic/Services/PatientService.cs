using System;
using System.Collections.Generic;
using System.Linq;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.BusinessLogicInterface;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public class PatientService : IPatientService
    {
        private ManagerPatientRepository patientRepository;
        private ManagerProblematicRepository problematicRepository;
        private ManagerPsychologistRepository psychologistRepository;
        private ManagerMeetingRepository meetingRepository;

        public PatientService(
            ManagerPatientRepository vRepository, 
            ManagerPsychologistRepository vPsyRepo,
            ManagerMeetingRepository vMeetingRepo
            )
        {
            patientRepository = vRepository;
            psychologistRepository = vPsyRepo;
            meetingRepository = vMeetingRepo;
        }

        public List<Patient> GetPatients()
        {
            return patientRepository.Patients.Get();
        }
        
        public Patient GetPatientsById(int patientId)
        {
            try
            {

                return patientRepository.Patients.Find(x => x.Id == patientId);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundPatient();
            }
        }


        public Patient SetPatient(Patient patient)
        {
            return patientRepository.Patients.Add(patient);
        }

        public Meeting ScheduleNewMeeting(Patient patient, Problematic problematic)
        {
            if (patient.Id != 0)
            {
                patient = patientRepository.Patients.Find(x => x.Id == patient.Id);
            }
            try
            {
                List<Psychologist> psychologists = psychologistRepository.Psychologists.Get();
                if (psychologists is null)
                    throw new NotFoundPsychologist();
                psychologists = psychologists.FindAll(x => 
                    x.Problematics != null && 
                    x.Problematics.Exists(x=> x.IsSameProblematicName(problematic.Name) || 
                                              x.Id == problematic.Id));
                psychologists = psychologists.OrderBy(
                    x => x.GetDayForNextMeetingOnWeek(DateTime.Today)).ToList();

                if(psychologists.Count == 0)
                    throw new NotFoundPsychologist();
                if (psychologists.Count > 1)
                    psychologists = psychologists.OrderBy(x => x.CreationDate).ToList();
                Psychologist psychologist = psychologists.First();
                
                DateTime auxDate = psychologist.GetDayForNextMeetingOnWeek(DateTime.Now);
                DateTime date = new DateTime(auxDate.Year, auxDate.Month, auxDate.Day, 0, 0, 0);

                string address;
                if (psychologist.WorksOnline)
                    address = $"https://bettercalm.com.uy/{psychologist.PsychologistId}_{patient.Id}/{Guid.NewGuid().ToString()}";
                else
                    address = psychologist.Address;
                

                Meeting meeting = new Meeting()
                {
                    Address = address,
                    DateTime = date,
                    Patient = patient,
                    Psychologist = psychologist
                };
                meetingRepository.Meetings.Add(meeting);
                return meeting;
            }
            catch (InvalidOperationException)
            {
                throw new AlreadyMeetingException();
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundPsychologist();
            }
        }
        
        public void DeletePatientById(int patientId)
        {
            
            Patient patient = GetPatientsById(patientId);
            patientRepository.Patients.Delete(patient);

        }

        public Patient UpdatePatient(Patient newPatient, int patientId)
        {
            Patient oldPatient = GetPatientsById(patientId);
            return patientRepository.Patients.Update(oldPatient, newPatient);
        }
    }
}