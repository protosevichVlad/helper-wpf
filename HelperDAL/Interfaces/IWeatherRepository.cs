using System.Threading.Tasks;
using HelperDAL.Models.API;

namespace HelperDAL.Interfaces
{
    public interface IWeatherRepository
    {
        Task<Current> GetCurrent();
        Task<Daily[]> GetForecast();
    }
}