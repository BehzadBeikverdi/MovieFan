using Microsoft.EntityFrameworkCore;
using MovieFan.Data;
using MovieFan.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFan.Repository
{
    public class MovieRepository<T> : IMovieRepository<T> where T : class
    {
        private readonly DataBaseContext _context;
        private readonly DbSet<T> _db;

        public MovieRepository(DataBaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task<IList<T>> GetAllMovies()
        {
            IQueryable<T> query = _db;
            return await query.AsNoTracking().ToListAsync();
        }
    }
}
