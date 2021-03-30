namespace MSP.BetterCalm.Domain
{
    public class Problematic
    
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj==null) return false;
            if (obj.GetType() != GetType()) return false;
            return Name == ((Problematic)obj).Name;
        }

        public bool IsSameProblematicName(string problematicName)
        {
            return Name == problematicName;
        }
    }
}