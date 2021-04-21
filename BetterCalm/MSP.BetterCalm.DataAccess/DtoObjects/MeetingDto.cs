using System;

namespace MSP.BetterCalm.DataAccess
{
    public class MeetingDto
    {
        public int PsychologistId { get; set; }
        public PsychologistDto Psychologist { get; set; }
        public int PatientId { get; set; }
        public PatientDto Patient { get; set; }
        public DateTime DateTime { get; set; }
    }
}