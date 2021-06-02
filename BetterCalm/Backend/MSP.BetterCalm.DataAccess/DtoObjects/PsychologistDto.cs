using System;
using System.Collections.Generic;

namespace MSP.BetterCalm.DataAccess.DtoObjects
{
    public class PsychologistDto: UserDto
    {
        public int PsychologistDtoId { get; set; }
        public string Address { get; set; }
        public bool WorksOnline { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<PsychologistProblematicDto> Problematics { get; set; }
        public virtual ICollection<MeetingDto> Meetings { get; set; }

    }
}