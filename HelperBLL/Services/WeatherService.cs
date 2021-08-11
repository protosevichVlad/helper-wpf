using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelperBLL.Interfaces;
using HelperBLL.Models;
using HelperDAL.Interfaces;
using HelperDAL.Models;
using HelperDAL.Repositories;

namespace HelperBLL.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _data;

        public WeatherService(HelperBLL.Models.Location location)
        {
            _data = new OpenWeatherMapRepository(new HelperDAL.Models.Location() {Lat = location.Lat, Lon = location.Lon});
        }

        public async Task<Weather> GetCurrentWeather()
        {
            var weather = (await _data.GetCurrent());
            return new Weather
            {
                Description = weather.Weather[0].Description,
                Temp = weather.Temp,
                FeelsLike = weather.FeelsLike,
                Icon = weather.Weather[0].Icon,
                Date = GetTimeFromUnixTime(weather.Dt),
            };
        }

        public async Task<List<Weather>> GetDailyWeather()
        {
            return (await _data.GetForecast()).Select(item => new Weather
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
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(unixTime);
        }
    }
}