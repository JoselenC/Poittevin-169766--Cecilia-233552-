using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer.Models;

namespace MSP.BetterCalm.Importer
{
    public interface IImporter
    {
        string GetImporterName();
        ListContentModel ImportContent(string path);
        List<Parameter> GetParameters();
    }
}