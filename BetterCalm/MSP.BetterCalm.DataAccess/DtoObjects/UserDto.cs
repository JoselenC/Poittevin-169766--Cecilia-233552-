
namespace MSP.BetterCalm.DataAccess
{
    public abstract class UserDto
    {
        public int UserDtoId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}