using MovieFan.Data;
using System;
using System.Threading.Tasks;

namespace MovieFan.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository<Movie> Movies { get; }

        IMessageRepository<Message> Messages { get; }

        IUserRepository<User> Users { get; }
        Task<int> Save();
    }
}
