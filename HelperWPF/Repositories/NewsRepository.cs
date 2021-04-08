using System.Collections.Generic;
using System.Threading.Tasks;
using HelperWPF.Interfaces;

namespace HelperWPF.Repositories
{
    public class NewsRepository : IRepository<News>
    {
        public async Task<News> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Weather>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}