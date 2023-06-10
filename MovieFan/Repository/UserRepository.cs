using Microsoft.EntityFrameworkCore;
using MovieFan.Data;
using MovieFan.IRepository;
using MovieFan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieFan.Repository
{
    public class UserRepository<T> : IUserRepository<T> where T : class
    {
        private readonly DataBaseContext _context;
        private readonly DbSet<User> _dbUser;
        private readonly DbSet<GenericResponse> _dbGenericResponse;

        public UserRepository(DataBaseContext context)
        {
            _context = context;
            _dbUser = _context.Set<User>();
            _dbGenericResponse = _context.Set<GenericResponse>();
        }
        public async Task AddUser(User Entity)
        {
            bool SearchData = await _dbUser.AllAsync(item => item.EmailAddress != Entity.EmailAddress);
            if (SearchData == true)
            {
                await _dbUser.AddAsync(Entity);
                Console.WriteLine("AddAsync");
            }
            else if (SearchData == false)
            {
                /*_dbUser.AsNoTracking();*/
                Console.WriteLine("AsNoTracking");
            }
            else
            {
               /* _dbUser.AnyAsync(Entity);*/
            }
        }
    }
}
