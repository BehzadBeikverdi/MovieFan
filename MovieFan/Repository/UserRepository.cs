using Microsoft.EntityFrameworkCore;
using MovieFan.Data;
using MovieFan.IRepository;
using MovieFan.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieFan.Repository
{
    public class UserRepository<T> : IUserRepository<T> where T : class
    {
        private readonly DataBaseContext _context;
        private readonly DbSet<User> _dbUser;

        public UserRepository(DataBaseContext context)
        {
            _context = context;
            _dbUser = _context.Set<User>();
        }

        public async Task DeleteUser(string EmailAddress)
        {
            var movieToDelete = await _dbUser.FindAsync(EmailAddress);
            if (movieToDelete != null)
            {
                _dbUser.Remove(movieToDelete);
            }
        }

        public async Task<bool> LoginUser(User Entity)
        {
     /*       DataTable dt = new DataTable("Users");
            DataRow[] row = dt.Select(Entity.EmailAddress);*/
            _context.Entry(Entity).GetDatabaseValues();
            
            var userEmail = Entity.EmailAddress;


            var userId = _dbUser.Where(i => i.EmailAddress == Entity.EmailAddress).Select(i => i.Id).FirstOrDefault();
            var userFirstname = _dbUser.Where(i => i.EmailAddress == Entity.EmailAddress).Select(i => i.Firstname).FirstOrDefault();
            var userLastname = _dbUser.Where(i => i.EmailAddress == Entity.EmailAddress).Select(i => i.Lastname).FirstOrDefault();

            bool userExist = false;

            if (userEmail != null)
            {
                bool checkFirstname = userFirstname == Entity.Firstname;
                bool checkLastname = userLastname == Entity.Lastname;

                if(checkFirstname && checkLastname)
                {
                    userExist = true;
                } else
                {
                    userExist = false;
                }

            } else
            {
                userExist = false;
            }
          
            return userExist;
        }

        public async Task RegisterUser(User Entity)
        {
            bool userExist = await _dbUser.AnyAsync(item => item.EmailAddress == Entity.EmailAddress);
            if (userExist == false)
            {
                await _dbUser.AddAsync(Entity);
            }
        }
    }
}
