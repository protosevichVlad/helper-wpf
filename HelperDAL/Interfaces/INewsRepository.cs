using HelperDAL.Models.Rss;
using System.Threading.Tasks;

namespace HelperDAL.Interfaces
{
    public interface INewsRepository
    {
        Task<Item[]> GetNews();
    }
}