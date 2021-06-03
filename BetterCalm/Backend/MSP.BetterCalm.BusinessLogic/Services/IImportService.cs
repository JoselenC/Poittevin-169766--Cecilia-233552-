using System.Collections.Generic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public interface IImportService
    {
        List<string> GetImportersName();
        List<Content> ImportContent(Import import);
        List<Parameter> GetParameters();
    }
}