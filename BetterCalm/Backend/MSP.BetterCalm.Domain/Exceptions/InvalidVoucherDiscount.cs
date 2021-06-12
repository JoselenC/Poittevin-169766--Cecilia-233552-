using System;

namespace MSP.BetterCalm.Domain.Exceptions
{
    public class InvalidVoucherDiscount: Exception
    {
        public InvalidVoucherDiscount() : 
            base("Invalid Voucher Discount")
        {
        }
    }
}