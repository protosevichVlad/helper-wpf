using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelperWPF.Interfaces;
using HelperWPF.ViewModel;

namespace HelperWPF.Services
{
    public class WeatherService
    {
        private readonly IWeatherRepository _data;

        public WeatherService(IWeatherRepository data)
        {
            _data = data;
        }

        public async Task<WeatherViewModel> GetCurrentWeather()
        {
            var weather = (await _data.GetCurrent());
            return new WeatherViewModel
            {
                Description = weather.Weather[0].Description,
                Temp = weather.Temp,
                FeelsLike = weather.FeelsLike,
                Icon = weather.Weather[0].Icon,
                Date = GetTimeFromUnixTime(weather.Dt),
            };
        }

        public async Task<List<WeatherViewModel>> GetDailyWeather()
        {
            return (await _data.GetForecast()).Select(item => new WeatherViewModel
            {
                Description = item.Weather[0].Description,
                Temp = item.Temp.Day,
                FeelsLike = item.FeelsLike.Day,
                Icon = item.Weather[0].Icon,
                Date = GetTimeFromUnixTime(item.Dt),
            }).ToList();
        }
        
        private DateTime GetTimeFromUnixTime(long unixTime)
        {
            return new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc).AddSeconds(unixTime);
        }
    }
}