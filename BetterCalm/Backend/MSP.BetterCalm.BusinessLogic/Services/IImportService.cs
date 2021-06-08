using System.Collections.Generic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer;
using MSP.BetterCalm.Importer.Models;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public interface IImportService
    {
        List<string> GetImportersName();
        ListContentModel ImportContent(Import import);
        List<Parameter> GetParameters();
    }
}