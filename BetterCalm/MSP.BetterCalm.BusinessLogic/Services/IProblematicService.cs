﻿using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface IProblematicService
    {
        public List<Problematic> GetProblematics();
        public Problematic GetProblematicByName(string name);

        public Problematic GetProblematicById(int id);
    }
}