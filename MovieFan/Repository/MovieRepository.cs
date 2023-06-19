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

        public async Task EditMovie(Movie Entity, int id)
        {
            bool movieToEdit = await _db.AnyAsync(item => item.Id == id);
            if (movieToEdit == true)
            {
                var movieDetail = await _db.FindAsync(id);
                movieDetail.MovieName = Entity.MovieName;
                movieDetail.MovieDirector = Entity.MovieDirector;
                movieDetail.MovieActors = Entity.MovieActors;
                movieDetail.MovieDescription = Entity.MovieDescription;
                movieDetail.MovieDuration = Entity.MovieDuration;
                movieDetail.MovieIMDB = Entity.MovieIMDB;
                movieDetail.ReleaseDate = Entity.ReleaseDate;
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
