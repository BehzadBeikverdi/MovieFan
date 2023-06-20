using MovieFan.Data;
using MovieFan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFan.IRepository
{
    public interface IUserRepository<T> where T : class
    {
        Task RegisterUser(User Entity);

        Task<bool> LoginUser(User Entity);

        Task DeleteUser(string EmailAddress);
    }
}
