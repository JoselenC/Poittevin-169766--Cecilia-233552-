namespace MSP.BetterCalm.Domain
{
    public class Problematic
    
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            return Id == ((Problematic)obj).Id;
        }

        public bool IsSameProblematicName(string problematicName)
        {
            if (problematicName == null) return false;
            return Name.ToLower() == problematicName.ToLower();
        }
    }
}