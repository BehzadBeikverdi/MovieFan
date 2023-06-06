using MovieFan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFan.IRepository
{
    public interface IMessageRepository<T> where T : class
    {
        Task SendMessage(T Entity);
    }
}
