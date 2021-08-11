using System.Collections.Generic;
using System.Threading.Tasks;
using HelperBLL.Models;

namespace HelperBLL.Interfaces
{
    public interface IWeatherService
    {
        public Task<Weather> GetCurrentWeather();
        public Task<List<Weather>> GetDailyWeather();
    }
}
