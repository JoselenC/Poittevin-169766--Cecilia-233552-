using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Importer
{
    public interface IImporter
    {
        string GetImporterName();
        List<Content> ImportContent(string path);
        List<Parameter> GetParameters();
    }
}