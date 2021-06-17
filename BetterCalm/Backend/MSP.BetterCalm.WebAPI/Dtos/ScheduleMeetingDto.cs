using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.WebAPI.Dtos
{
    public class ScheduleMeetingDto
    {
        public Patient Patient { get; set; }
        public Problematic Problematic { get; set; }
        
        public double Duration { get; set; }
    }
}