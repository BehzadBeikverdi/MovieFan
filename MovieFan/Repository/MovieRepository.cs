using Microsoft.EntityFrameworkCore;
using MovieFan.Data;
using MovieFan.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieFan.Repository
{
    public class MovieRepository<T> : IMovieRepository<T> where T : class
    {
        private readonly DataBaseContext _context;
        private readonly DbSet<Movie> _db;

        public MovieRepository(DataBaseContext context)
        {
            _context = context;
            _db = _context.Set<Movie>();
        }

        public async Task DeleteMovieById(int id)
        {
            /*var movieToDelte = await _db.FirstOrDefaultAsync(item => item.Id == id);*/
            var movieToDelte = await _db.AllAsync(item => item.Id == id);
            if (movieToDelte == true)
            {
                Movie entity = _db.Find(id);
                _db.Remove(entity);
            }
            /*      _db.Remove(movieToDelte);*/
        }

        public async Task<IList<Movie>> GetAllMovies()
        {
            IQueryable<Movie> query = _db;
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Movie> GetById(Expression<Func<Movie, bool>> expression = null, List<string> list = null)
        {
            IQueryable<Movie> query = _db;

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task InsertMovie(Movie Entity)
        {
            await _db.AddAsync(Entity);
        }

    }
}
