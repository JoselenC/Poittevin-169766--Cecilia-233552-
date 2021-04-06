using System;

namespace MSP.BetterCalm.DataAccess
{
    public class PatientDto: UserDto
    {
        public int PatientDtoId { get; set; }
        public string Cellphone { get; set; }
        public DateTime BirthDay { get; set; }
        
    }
}