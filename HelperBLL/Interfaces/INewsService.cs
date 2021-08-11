using System.Collections.Generic;
using System.Threading.Tasks;
using HelperBLL.Models;

namespace HelperBLL.Interfaces
{
    public interface INewsService
    {
        Task<List<News>> GetAllNews();
    }
}
