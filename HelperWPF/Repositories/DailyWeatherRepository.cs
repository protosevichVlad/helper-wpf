using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelperWPF.Interfaces;
using Newtonsoft.Json;

namespace HelperWPF.Repositories
{
    public class DailyWeatherRepository : IRepository<Weather>
    {
        public async Task<Weather> Get(int number)
        {
            if (number > 5 || number < 1)
            {
                throw new AggregateException("number more than 5 or less than 1");
            }

            return (await this.GetAll()).ElementAt(number + 1);
        }

        public async Task<IEnumerable<Weather>> GetAll()
        {
            List<Weather> weathers = new List<Weather>();

            string GETUSER_URL = String.Format("http://api.openweathermap.org/data/2.5/onecall?lat=53.893009&lon=27.567444&cnt=7&units=metric&lang=ru&appid=518b92b3cbdf13f93c7da5e925eeddef");
            using (var getUsers = new HttpClient())
            {
                var result = await getUsers.GetStringAsync(GETUSER_URL);
                dynamic json = JsonConvert.DeserializeObject(result);
                foreach (var values in json.daily)
                {
                    Weather weather = new Weather(values.dt.ToString(), values.temp.day.ToString(), values.feels_like.day.ToString(), values.weather[0].description.ToString(), values.weather[0].icon.ToString() );
                    weathers.Add(weather);
                }
            }
            
            return weathers;
        }
    }
}