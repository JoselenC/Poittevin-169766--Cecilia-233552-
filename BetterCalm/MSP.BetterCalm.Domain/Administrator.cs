using System;

namespace MSP.BetterCalm.Domain
{
    public class Administrator: User
    {
        public int AdministratorId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        protected bool Equals(Administrator other)
        {
            return Email == other.Email && 
                   Token == other.Token &&
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

    }
}