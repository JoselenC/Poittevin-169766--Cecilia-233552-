using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace MSP.BetterCalm.Importer
{
    public class Parameter
    {
        public string Name { get; set; }
        
        private string type;
        public string Type { get=>type; set=>SetType(value); }

        private readonly string[] _validParameterTypes = {"string","int", "date","bool"};
        private void SetType(string typ)
        {
            if (_validParameterTypes.Contains(typ.ToLower()))
                type = typ;
            else
                throw new InvalidType();
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            return Name == ((Parameter)obj).Name && Type == ((Parameter)obj).Type;
        }
    }
}