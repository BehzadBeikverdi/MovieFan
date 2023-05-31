using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieFan.IRepository
{
    public interface IMovieRepository<T> where T : class
    {
        Task<IList<T>> GetAllMovies();

        Task<T> GetById(Expression<Func<T, bool>> expression = null, List<string> list = null);
    }
}
