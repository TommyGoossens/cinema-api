using Cinema.Domain.Interfaces;

namespace Cinema.Domain.Models
{
	public class User : IAggregateRoot
    {
		public int Id { get; set; }
		public string UserName { get; set; }

        public User(int id, string userName)
        {
            Id = id;
            UserName = userName;
        }
    }
}

