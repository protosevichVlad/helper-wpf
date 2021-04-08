using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HelperWPF.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        Task<IEnumerable<Weather>> GetAll();
    }
}