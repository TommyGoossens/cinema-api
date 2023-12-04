using Cinema.Domain.Models;

namespace Cinema.Infrastructure.Repositories.Interfaces
{
	public interface ITheaterRepository : IRepository<Theater>
	{
        IEnumerable<Theater> GetTheaters();
        Theater GetTheaterByID(int theaterId);
        Theater CreateTheater(Theater theater);
        bool DeleteTheater(int theaterID);
        Theater UpdateTheater(Theater theater);
        void Save();
    }
}

