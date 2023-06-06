using MovieFan.Data;
using MovieFan.IRepository;
using System;
using System.Threading.Tasks;

namespace MovieFan.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;
        private IMovieRepository<Movie> _movies;
        private IMessageRepository<Message> _messages;

        public UnitOfWork (DataBaseContext context)
        {
            _context = context;
        }

        public IMovieRepository<Movie> Movies => _movies ??= new MovieRepository<Movie>(_context);

        public IMessageRepository<Message> Messages => _messages ??= new MessageRepository<Message>(_context);

        public void Dispose()
        {
            _context.Dispose();
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
