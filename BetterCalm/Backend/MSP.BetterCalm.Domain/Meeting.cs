using System;
using MSP.BetterCalm.Domain.Exceptions;

namespace MSP.BetterCalm.Domain
{
    public class Meeting
    {
        
        public Psychologist Psychologist { get; set; }
        public Patient Patient { get; set; }
        public DateTime DateTime { get; set; }
        public string Address { get; set; }
        private Times _duration { get; set; }
        public double Cost { get; set; }
        public double Duration { get => DurationGet(); set => DurationSet(value); }

        private void DurationSet(double durationValue)
        {
            switch (durationValue)
            {
                case 2:
                    _duration = Times.Long;
                    break;
                case 1.5:
                    _duration = Times.Medium;
                    break;
                case 1:
                    _duration = Times.Short;
                    break;
                default:
                    throw new InvalidMeetingDuration(); 
            }
        }
        
        private double DurationGet()
        {
            switch (_duration)
            {
                case Times.Long:
                    return 2;
                case Times.Medium:
                    return 1.5;
                case Times.Short:
                    return 1;
                default:
                    throw new InvalidMeetingDuration(); 
            }
        }
        
        protected bool Equals(Meeting other)
        {
            bool hasSamePsychology = Equals(Psychologist, other.Psychologist);
            bool hasSamePatient = Equals(Patient, other.Patient);
            bool hasSameAddress = Address == other.Address;
            bool hasSameDateTime = DateTime.Equals(other.DateTime);
            return hasSamePatient && hasSamePsychology && hasSameAddress && hasSameDateTime;
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