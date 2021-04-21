using System;

namespace MSP.BetterCalm.DataAccess
{
    public class MeetingDto
    {
        public int PsychologistId { get; set; }
        public virtual PsychologistDto Psychologist { get; set; }
        public int PatientId { get; set; }
        public virtual PatientDto Patient { get; set; }
        public DateTime DateTime { get; set; }
    }
}