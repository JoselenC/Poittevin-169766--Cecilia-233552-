namespace MSP.BetterCalm.DataAccess
{
    public class PsychologistProblematicDto
    {
            public int PsychologistId { get; set; }
            public virtual PsychologistDto Psychologist { get; set; }
            public int ProblematicId { get; set; }
            public virtual ProblematicDto Problematic { get; set; }
        
    }
}