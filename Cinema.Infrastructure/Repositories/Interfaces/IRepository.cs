using System;
using Cinema.Domain.Interfaces;

namespace Cinema.Infrastructure.Repositories.Interfaces
{
	public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
	}
}

