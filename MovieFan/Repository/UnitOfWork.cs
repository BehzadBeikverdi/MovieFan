﻿using MovieFan.Data;
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
        private IUserRepository<User> _users;

        public UnitOfWork (DataBaseContext context)
        {
            _context = context;
        }

        public IMovieRepository<Movie> Movies => _movies ??= new MovieRepository<Movie>(_context);

        public IMessageRepository<Message> Messages => _messages ??= new MessageRepository<Message>(_context);

        public IUserRepository<User> Users => _users ??= new UserRepository<User>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            var x=await _context.SaveChangesAsync();
            return x;
        }
    }
}
