using System;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public class GuidService: IGuidService
    {
        public Guid NewGuid() { return Guid.NewGuid(); }
    }
}