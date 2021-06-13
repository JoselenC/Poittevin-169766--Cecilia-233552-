using System;
using MSP.BetterCalm.Domain.Exceptions;

namespace MSP.BetterCalm.Domain
{
    public class Voucher
    {
        public int VoucherId { get; set; }
        public Patient Patient { get; set; }
        public int MeetingsAmount { get; set; }
        public Status Status { get; set; } = Status.NotReady;
        public Discounts Discount { get; set; }
        protected bool Equals(Voucher other)
        {
            return VoucherId == other.VoucherId && 
                   MeetingsAmount == other.MeetingsAmount && 
                   Status == other.Status &&
                   Discount == other.Discount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Voucher) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(VoucherId, MeetingsAmount, (int) Status, (int) Discount);
        }
    }
}