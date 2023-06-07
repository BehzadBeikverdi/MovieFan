using Microsoft.EntityFrameworkCore;
using MovieFan.Data;
using MovieFan.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFan.Repository
{
    public class UserRepository<T> : IUserRepository<T> where T : class
    {
        private readonly DataBaseContext _context;
        private readonly DbSet<User> _db;

        public UserRepository(DataBaseContext context)
        {
            _context = context;
            _db = _context.Set<User>();
        }
        public async Task AddUser(User Entity, GenericResponse responseGeneric)
        {
            if(await _db.AnyAsync(item => item.EmailAddress != Entity.EmailAddress)) 
            {
                await _db.AddAsync(Entity);
                
            } else
            {
               a
            }
            
        }
    }
}
