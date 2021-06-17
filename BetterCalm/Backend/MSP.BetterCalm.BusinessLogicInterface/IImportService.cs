using System.Collections.Generic;
using MSP.BetterCalm.Importer;
using MSP.BetterCalm.Importer.Models;

namespace MSP.BetterCalm.BusinessLogicInterface
{
    public interface IImportService
    {
        List<string> GetImportersName();
        string ImportContent(Import import);
        List<Parameter> GetParameters();
    }
}