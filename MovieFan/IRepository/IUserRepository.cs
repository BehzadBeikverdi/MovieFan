using MovieFan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFan.IRepository
{
    public interface IUserRepository<T> where T : class
    {
        Task AddUser(User Entity, GenericResponse responseGeneric);
    }
}
