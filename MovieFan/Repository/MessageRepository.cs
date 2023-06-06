using Microsoft.EntityFrameworkCore;
using MovieFan.Data;
using MovieFan.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFan.Repository
{
    public class MessageRepository<T> : IMessageRepository<T> where T : class
    {

        private readonly DataBaseContext _context;
        private readonly DbSet<T> _db;

        public MessageRepository(DataBaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task SendMessage(T Entity)
        {
            await _db.AddAsync(Entity);
        }
    }
}
