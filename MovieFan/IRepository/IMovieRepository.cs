using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieFan.IRepository
{
    public interface IMovieRepository<T> where T : class
    {
        Task<IList<T>> GetAllMovies();
    }
}
