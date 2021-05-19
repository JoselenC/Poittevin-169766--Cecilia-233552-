using System;

namespace MSP.BetterCalm.BusinessLogic
{
    public class GuidService: IGuidService
    {
        public Guid NewGuid() { return Guid.NewGuid(); }
    }
}