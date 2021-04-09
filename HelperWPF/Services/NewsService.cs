using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelperWPF.Interfaces;

namespace HelperWPF.Services
{
    public class NewsService
    {
        private readonly IRepository<News> _data;

        public NewsService(IRepository<News> data)
        {
            _data = data;
        }
        
        public async Task<List<News>> GetAllNews()
        {
            return (await _data.GetAll()).ToList();
        }
    }
}