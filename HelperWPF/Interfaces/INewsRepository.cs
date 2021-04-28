using System.Collections.Generic;
using System.Threading.Tasks;
using HelperWPF.Models;
using HelperWPF.Models.Rss;

namespace HelperWPF.Interfaces
{
    public interface INewsRepository
    {
        Task<Item[]> GetNews();
    }
}