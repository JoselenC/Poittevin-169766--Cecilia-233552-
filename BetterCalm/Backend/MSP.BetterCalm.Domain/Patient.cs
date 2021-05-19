using System;
using System.Collections.Generic;
using System.Linq;

namespace MSP.BetterCalm.Domain
{
    public class Patient: User
    {
        public int Id { get; set; }
        public string Cellphone { get; set; }
        public DateTime BirthDay { get; set; }
        public List<Meeting> Meetings{ get; set; }
        public Patient()
        {
            Meetings = new List<Meeting>();
        }
        protected bool Equals(Patient other)
        {
            return Id == other.Id &&
                   Name == other.Name &&
                   LastName == other.LastName &&
                   Cellphone == other.Cellphone &&
                   BirthDay.Equals(other.BirthDay) &&
                   Meetings.OrderBy(
                       x => x.Psychologist.PsychologistId).SequenceEqual(
                       other.Meetings.OrderBy(
                           x => x.Psychologist.PsychologistId)); ;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Patient) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Cellphone, BirthDay, Meetings);
        }


    }
}