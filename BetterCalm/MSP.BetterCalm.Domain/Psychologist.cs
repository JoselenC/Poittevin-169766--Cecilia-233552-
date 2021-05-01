using System;
using System.Collections.Generic;
using System.Linq;

namespace MSP.BetterCalm.Domain
{
    public class Psychologist: User
    {
        public int PsychologistId { get; set; }
        public string Address { get; set; }
        public bool WorksOnline { get; set; }
        public List<Problematic> Problematics{ get; set; }
        public List<Meeting> Meetings{ get; set; }
        public DateTime CreationDate { get; set;}

        public Psychologist()
        {
            Meetings = new List<Meeting>();
            Problematics = new List<Problematic>();
        }
        protected bool Equals(Psychologist other)
        {
            return Address == other.Address &&
                   CreationDate == other.CreationDate &&
                   Name == other.Name &&
                   LastName == other.LastName &&
                   WorksOnline == other.WorksOnline &&
                   Problematics.OrderBy(
                       x => x.Id).SequenceEqual(
                       other.Problematics.OrderBy(
                           x => x.Id));
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


        public DateTime GetDayForNextMeetingOnWeek(DateTime weekDay)
        {
            int daysBeforeSaturday = (int) DayOfWeek.Saturday - (int) weekDay.DayOfWeek;
            // If it's Saturday or Sunday, I start the weekday on Monday 
            if (daysBeforeSaturday == 0 || daysBeforeSaturday == 6)
            {
                weekDay = weekDay.AddDays(8 - (int) weekDay.DayOfWeek);
                daysBeforeSaturday = 5;
            }
            for (int i = 0; i < daysBeforeSaturday; i++)
            {
                weekDay = weekDay.AddDays(i == 0 ? 0 : 1);
                IEnumerable<Meeting> meetings =
                    Meetings.Where(
                        x => x.DateTime.DayOfYear == weekDay.DayOfYear && x.DateTime.Year == weekDay.Year
                    );
                if (meetings.Count() < 5)
                    return weekDay;
            }
            //At this point, the day should be a Friday, I Add 3 days to start on Monday adn then look again.
            weekDay = weekDay.AddDays(3);
            return GetDayForNextMeetingOnWeek(weekDay);
        }
    }
}