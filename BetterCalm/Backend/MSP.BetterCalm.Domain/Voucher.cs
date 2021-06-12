using MSP.BetterCalm.Domain.Exceptions;

namespace MSP.BetterCalm.Domain
{
    public class Voucher
    {
        public int VoucherId { get; set; }
        public Patient Patient { get; set; }
        public Psychologist Psychologist { get; set; }
        public int MeetingsAmount { get; set; }
        public Status Status { get; set; } = Status.NotReady;
        public Discounts Discount { get; set; }
        

    }
}