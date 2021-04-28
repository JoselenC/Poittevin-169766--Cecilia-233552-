namespace MSP.BetterCalm.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj==null) return false;
            if (obj.GetType() != GetType()) return false;
            return Name == ((Category)obj).Name && Id == ((Category)obj).Id;
        }
      
        public bool IsSameCategoryName(string categoryName)
        { 
            return Name == categoryName;
        }
    }
}