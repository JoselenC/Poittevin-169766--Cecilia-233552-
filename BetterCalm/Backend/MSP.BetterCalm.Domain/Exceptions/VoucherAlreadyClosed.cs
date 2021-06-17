using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class VoucherAlreadyClosed: Exception
    {
        public VoucherAlreadyClosed() :
            base("This Voucher is already closed (pending for admin response or already used)")
        { }
    }
}