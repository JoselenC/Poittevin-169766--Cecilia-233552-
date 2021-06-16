using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;

namespace MSP.BetterCalm.Importer
{
    public class Import
    {
        private string _name;
        public string Name {get=>_name; set=>SetName(value); }
        private void SetName(string vName)
        {
            if (vName.Length>0)
                _name = vName;
            else
                throw new InvalidNameLength();
        }
        public List<Parameter> Parameters { get; set; }
        public string Path { get; set; }

    }
}