using MovieFan.Data;
using System;
using System.Threading.Tasks;

namespace MovieFan.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository<Movie> Movies { get; }
        Task Save();
    }
}
