using System.Threading.Tasks;
using HelperWPF.Models.API;

namespace HelperWPF.Interfaces
{
    public interface IWeatherRepository
    {
        Task<Current> GetCurrent();
        Task<Daily[]> GetForecast();
    }
}