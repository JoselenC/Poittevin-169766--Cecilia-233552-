namespace MSP.BetterCalm.Domain
{
    public class Category
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj==null) return false;
            if (obj.GetType() != GetType()) return false;
            return Name == ((Category)obj).Name;
        }
      
        public bool IsSameCategoryName(string categoryName)
        { 
            return Name == categoryName;
        }
    }
}