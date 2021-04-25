using System;
using System.Collections.Generic;

namespace MSP.BetterCalm.Domain
{
    public class Patient: User
    {
        
        public string Cellphone { get; set; }
        public DateTime BirthDay { get; set; }
        public List<Meeting> Meetings{ get; set; }
        protected bool Equals(Patient other)
        {
            return Cellphone == other.Cellphone && BirthDay.Equals(other.BirthDay);
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
            return HashCode.Combine(Cellphone, BirthDay);
        }

    }
}