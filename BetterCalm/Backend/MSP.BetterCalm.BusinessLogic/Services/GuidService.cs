using System;
using MSP.BetterCalm.BusinessLogicInterface;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public class GuidService: IGuidService
    {
        public Guid NewGuid() { return Guid.NewGuid(); }
    }
}