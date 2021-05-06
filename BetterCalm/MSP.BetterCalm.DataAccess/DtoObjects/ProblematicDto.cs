using System.Collections.Generic;

namespace MSP.BetterCalm.DataAccess
{
    public class ProblematicDto
    {
        public int ProblematicDtoID { get; set; }
        
        public string Name { get; set; }
        
        public virtual ICollection<PsychologistProblematicDto> PsychologistProblematic { get; set; }
    }
}