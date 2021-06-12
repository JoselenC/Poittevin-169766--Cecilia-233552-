using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.DtoObjects
{
    public class VoucherDto
    {
        public int VoucherDtoId { get; set; }
        public PatientDto Patient { get; set; }
        public PsychologistDto Psychologist { get; set; }
        public int MeetingsAmount { get; set; }
        public Status Status { get; set; }
        public Discounts Discount { get; set; }
    }
}