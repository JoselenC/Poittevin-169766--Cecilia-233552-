using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface IProblematicLogic
    {
        public List<Problematic> GetProblematics();
        public Problematic GetProblematicByName(string name);
        public void SetProblematic(Problematic problematic);
    }
}