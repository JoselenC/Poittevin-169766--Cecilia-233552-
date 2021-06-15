using System;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain.Exceptions;

namespace MSP.BetterCalm.Domain
{
    public class Voucher
    {
        public int VoucherId { get; set; }
        public Patient Patient { get; set; }
        private int _meetingAmount { get; set; } = 1;
        public int MeetingsAmount
        {
            get => _meetingAmount;
            set => SetMeetingsAmount(value);
        }

        public Status Status { get; set; } = Status.NotReady;
        public Discounts Discount { get; set; } = Discounts.Low;

        protected bool Equals(Voucher other)
        {
            return VoucherId == other.VoucherId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Voucher) obj);
        }

        public void SetMeetingsAmount(int value)
        {
            _meetingAmount = value;
            if (Status == Status.Rejected || Status == Status.Used)
            {
                throw new VoucherAlreadyClosed();
            }

            if (value >= 5 && Status != Status.Approved && Status != Status.Used)
            {
                Status = Status.Pending;
            }
        }
    }
}