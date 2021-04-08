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
    }
}