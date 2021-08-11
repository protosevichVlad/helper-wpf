using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelperDAL.Interfaces;
using HelperDAL.Models;
using HelperDAL.Models.API;
using Newtonsoft.Json;

namespace HelperDAL.Repositories
{
    public class OpenWeatherMapRepository : IWeatherRepository
    {
        public string Url => $"http://api.openweathermap.org/data/2.5/onecall?lat={_location.Lat}&lon={_location.Lon}&cnt=7&units=metric&lang=ru&appid={Service.OpenWeatherMapKey}";
        
        private readonly Location _location;
        private Weather Weather = null;
        
        public OpenWeatherMapRepository(Location location)
        {
            this._location = location;
        }
        
        public async Task<Current> GetCurrent()
        {
            if (Weather == null)
            {
                await Request();
            }
            
            return Weather?.Current;
        }

        public async Task<Daily[]> GetForecast()
        {
            if (Weather == null)
            {
                await Request();
            }
            
            return Weather?.Daily;
        }

        private async Task Request()
        {
            using (var getWeather = new HttpClient())
            {
                var result = await getWeather.GetStringAsync(this.Url);
                Weather = JsonConvert.DeserializeObject<Weather>(result);
            }
        }
    }
}