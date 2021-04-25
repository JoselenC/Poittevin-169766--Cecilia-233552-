using System;
using System.Collections.Generic;
using System.Linq;

namespace MSP.BetterCalm.Domain
{
    public class Psychologist: User
    {
        public string Address { get; set; }
        public bool WorksOnline { get; set; }

        public List<Problematic> Problematics{ get; set; }
        public List<Meeting> Meetings{ get; set; }
        protected bool Equals(Psychologist other)
        {
            return
                Address == other.Address &&
                Name == other.Name &&
                LastName == other.LastName &&
                WorksOnline == other.WorksOnline;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Psychologist) obj);
        }

        public override int GetHashCode()
        {
            return (Address != null ? Address.GetHashCode() : 0);
        }


        public DateTime? GetDayForNextMeetingOnWeek(DateTime week)
        {
            int daysBeforeSaturday = (int) DayOfWeek.Saturday - (int) week.DayOfWeek;
            for (int i = 0; i < daysBeforeSaturday; i++)
            {
                DateTime weekDay = week.AddDays(i);
                IEnumerable<Meeting> meetings =
                    Meetings.Where(
                        x => x.DateTime.DayOfYear == weekDay.DayOfYear && x.DateTime.Year == x.DateTime.Year
                    );
                if (meetings.Count() < 5)
                    return week.AddDays(i);
            }

            return null;
        }
    }
}