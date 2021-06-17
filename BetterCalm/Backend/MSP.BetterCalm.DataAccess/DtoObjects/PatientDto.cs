using System;
using System.Collections.Generic;

namespace MSP.BetterCalm.DataAccess.DtoObjects
{
    public class PatientDto: UserDto
    {
        public int PatientDtoId { get; set; }
        public string Cellphone { get; set; }
        public DateTime BirthDay { get; set; }
        public virtual ICollection<MeetingDto> Meetings { get; set; }
    }
}