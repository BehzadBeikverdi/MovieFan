using Microsoft.EntityFrameworkCore;
using MovieFan.Data;
using MovieFan.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
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
            var movieToDelete = await _db.FindAsync(id);
            if (movieToDelete != null)
            {
                Movie entity = _db.Find(id);
                _db.Remove(entity);
            }
        }

        public async Task EditMovie(Movie Entity)
        {
            var movieToEdit = await _db.FindAsync(Entity.Id);
            if (movieToEdit != null)
            {
                movieToEdit.MovieName = Entity.MovieName;
                movieToEdit.MovieDirector = Entity.MovieDirector;
                movieToEdit.MovieActors = Entity.MovieActors;
                movieToEdit.MovieDescription = Entity.MovieDescription;
                movieToEdit.MovieDuration = Entity.MovieDuration;
                movieToEdit.MovieIMDB = Entity.MovieIMDB;
                movieToEdit.ReleaseDate = Entity.ReleaseDate;
            }
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
