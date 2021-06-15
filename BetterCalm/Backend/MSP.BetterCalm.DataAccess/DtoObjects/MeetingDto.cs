using System;

namespace MSP.BetterCalm.DataAccess.DtoObjects
{
    public class MeetingDto
    {
        public int PsychologistId { get; set; }
        public virtual PsychologistDto Psychologist { get; set; }
        public int PatientId { get; set; }
        public virtual PatientDto Patient { get; set; }
        public DateTime DateTime { get; set; }
        public string Address { get; set; }
        public double Duration { get; set; }
        public double Cost { get; set; }
    }
}