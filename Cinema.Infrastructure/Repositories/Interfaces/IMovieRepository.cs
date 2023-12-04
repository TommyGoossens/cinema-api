using Cinema.Domain.Models;

namespace Cinema.Infrastructure.Repositories.Interfaces
{
    public class IMovieRepository : IRepository<Movie>
	{
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

