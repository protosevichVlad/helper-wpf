using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelperWPF.Interfaces;

namespace HelperWPF.Services
{
    public class WeatherService
    {
        private readonly IRepository<Weather> _data;

        public WeatherService(IRepository<Weather> data)
        {
            _data = data;
        }

        public async Task<Weather> GetCurrentWeather()
        {
            return (await _data.GetAll()).ElementAt(0);
        }

        public async Task<List<Weather>> GetDailyWeather()
        {
            return (await _data.GetAll()).Skip(1).ToList();
        }
    }
}