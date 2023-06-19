using MovieFan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieFan.IRepository
{
    public interface IMovieRepository<T> where T : class
    {
        Task<IList<Movie>> GetAllMovies();

        Task<Movie> GetById(Expression<Func<Movie, bool>> expression = null, List<string> list = null);

        Task InsertMovie(Movie Entity);

        Task DeleteMovieById(int id);

        Task EditMovie(Movie Entity, int id);
    }
}
