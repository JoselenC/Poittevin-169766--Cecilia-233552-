using System;

namespace MSP.BetterCalm.Domain
{
    public class Administrator: User
    {
        protected bool Equals(Administrator other)
        {
            return 
                Email == other.Email && 
                Password == other.Password &&
                Name == other.Name &&
                LastName == other.LastName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Administrator) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Email, Password);
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}