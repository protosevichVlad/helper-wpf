using System;

namespace HelperWPF
{
    public class Weather
    {
        public readonly DateTime Date;
        
        public readonly double Temp;
        
        public readonly double FeelsLike;
        
        public readonly string Description;

        public readonly string Icon;

        public string IconUrl
        {
            get
            {
                return $"http://openweathermap.org/img/wn/{Icon}@2x.png";
            }
        }

        public Weather(string date, string temp, string feelsLike, string description, string icon)
        {
            Date = new DateTime(1970, 1, 1).AddSeconds(double.Parse(date)).Date;
            Temp = double.Parse(temp);
            FeelsLike = double.Parse(feelsLike);
            Description = description;
            Icon = icon;
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
}