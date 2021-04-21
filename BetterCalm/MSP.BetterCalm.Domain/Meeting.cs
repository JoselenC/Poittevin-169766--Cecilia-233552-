using System;

namespace MSP.BetterCalm.Domain
{
    public class Meeting
    {
        public Psychologist Psychologist { get; set; }
        public Patient Patient { get; set; }
        public DateTime DateTime { get; set; }
    }
}