using System;

namespace MSP.BetterCalm.Domain
{
    public class Meeting
    {
        
        public Psychologist Psychologist { get; set; }
        public Patient Patient { get; set; }
        public DateTime DateTime { get; set; }
        public string Address { get; set; }

        protected bool Equals(Meeting other)
        {
            return Equals(Psychologist, other.Psychologist) && 
                   Equals(Patient, other.Patient) && 
                   Address == other.Address &&
                   DateTime.Equals(other.DateTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Meeting) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Psychologist, Patient, DateTime);
        }

    }
}