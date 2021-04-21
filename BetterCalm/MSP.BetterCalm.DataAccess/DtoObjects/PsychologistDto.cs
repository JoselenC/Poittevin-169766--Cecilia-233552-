using System.Collections.Generic;

namespace MSP.BetterCalm.DataAccess
{
    public class PsychologistDto: UserDto
    {
        public int PsychologistDtoId { get; set; }
        public string Address { get; set; }
        public bool WorksOnline { get; set; }
        public virtual ICollection<PsychologistProblematicDto> PsychologistProblematic { get; set; }
        public virtual ICollection<MeetingDto> Meetings { get; set; }

    }
}