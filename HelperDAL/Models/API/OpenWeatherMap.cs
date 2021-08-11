using System;
using Newtonsoft.Json;

namespace HelperDAL.Models.API
{
    public class Weather
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("timezone_offset")]
        public long TimezoneOffset { get; set; }

        [JsonProperty("current")]
        public Current Current { get; set; }

        [JsonProperty("minutely")]
        public Minutely[] Minutely { get; set; }

        [JsonProperty("hourly")]
        public Current[] Hourly { get; set; }

        [JsonProperty("daily")]
        public Daily[] Daily { get; set; }
    }

    public class Current
    {
        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("sunrise", NullValueHandling = NullValueHandling.Ignore)]
        public long? Sunrise { get; set; }

        [JsonProperty("sunset", NullValueHandling = NullValueHandling.Ignore)]
        public long? Sunset { get; set; }

        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("dew_point")]
        public double DewPoint { get; set; }

        [JsonProperty("uvi")]
        public double Uvi { get; set; }

        [JsonProperty("clouds")]
        public long Clouds { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("wind_deg")]
        public long WindDeg { get; set; }

        [JsonProperty("weather")]
        public WeatherElement[] Weather { get; set; }

        [JsonProperty("wind_gust", NullValueHandling = NullValueHandling.Ignore)]
        public double? WindGust { get; set; }

        [JsonProperty("pop", NullValueHandling = NullValueHandling.Ignore)]
        public double? Pop { get; set; }

        [JsonProperty("rain", NullValueHandling = NullValueHandling.Ignore)]
        public Rain Rain { get; set; }
    }

    public class Rain
    {
        [JsonProperty("1h")]
        public double The1H { get; set; }
    }

    public class WeatherElement
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
        
        [JsonIgnore]
        public string IconUrl
        {
            get
            {
                return $"http://openweathermap.org/img/wn/{Icon}@2x.png";
            }
        }

        public string GetIconUrl(int scale)
        {
            if (scale < 1)
            {
                throw new ArgumentException("scale less than 1");
            }
            
            return $"http://openweathermap.org/img/wn/{Icon}@{scale}x.png";
        }
    }

    public class Daily
    {
        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }

        [JsonProperty("sunset")]
        public long Sunset { get; set; }

        [JsonProperty("moonrise")]
        public long Moonrise { get; set; }

        [JsonProperty("moonset")]
        public long Moonset { get; set; }

        [JsonProperty("moon_phase")]
        public double MoonPhase { get; set; }

        [JsonProperty("temp")]
        public Temp Temp { get; set; }

        [JsonProperty("feels_like")]
        public FeelsLike FeelsLike { get; set; }

        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("dew_point")]
        public double DewPoint { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("wind_deg")]
        public long WindDeg { get; set; }

        [JsonProperty("wind_gust")]
        public double WindGust { get; set; }

        [JsonProperty("weather")]
        public WeatherElement[] Weather { get; set; }

        [JsonProperty("clouds")]
        public long Clouds { get; set; }

        [JsonProperty("pop")]
        public double Pop { get; set; }

        [JsonProperty("uvi")]
        public double Uvi { get; set; }

        [JsonProperty("rain", NullValueHandling = NullValueHandling.Ignore)]
        public double? Rain { get; set; }
    }

    public class FeelsLike
    {
        [JsonProperty("day")]
        public double Day { get; set; }

        [JsonProperty("night")]
        public double Night { get; set; }

        [JsonProperty("eve")]
        public double Eve { get; set; }

        [JsonProperty("morn")]
        public double Morn { get; set; }
    }

    public class Temp
    {
        [JsonProperty("day")]
        public double Day { get; set; }

        [JsonProperty("min")]
        public double Min { get; set; }

        [JsonProperty("max")]
        public double Max { get; set; }

        [JsonProperty("night")]
        public double Night { get; set; }

        [JsonProperty("eve")]
        public double Eve { get; set; }

        [JsonProperty("morn")]
        public double Morn { get; set; }
    }

    public class Minutely
    {
        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("precipitation")]
        public long Precipitation { get; set; }
    }
}