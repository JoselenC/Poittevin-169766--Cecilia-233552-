using System;

namespace MSP.BetterCalm.Domain.Exceptions
{
    public class InvalidMeetingDuration : Exception
    {
        public InvalidMeetingDuration() : 
            base("Invalid Meeting Duration")
        {
        }
    }
}