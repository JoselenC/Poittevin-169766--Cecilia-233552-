using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NotFoundVoucher: Exception
    {
        public NotFoundVoucher() :
            base("No Voucher found")
        {
        }
    }
}