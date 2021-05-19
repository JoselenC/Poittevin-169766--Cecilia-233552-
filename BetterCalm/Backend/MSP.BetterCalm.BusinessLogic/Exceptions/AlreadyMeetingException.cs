using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class AlreadyMeetingException: Exception
    {
        public AlreadyMeetingException():
            base("This patient and psychologist already have a pending meeting soon")
        {}
        
    }
}