using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NotFoundAdminLoginError: Exception
    {
        public NotFoundAdminLoginError():
            base("Error authenticating, incorrect Email or Password")
        {
        }
    }
}