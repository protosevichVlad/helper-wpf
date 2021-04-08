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

        public Weather(string date, string temp, string feelsLike, string description, string icon)
        {
            Date = new DateTime(1970, 1, 1).AddSeconds(double.Parse(date)).Date;
            Temp = double.Parse(temp);
            FeelsLike = double.Parse(feelsLike);
            Description = description;
            Icon = icon;
        }
    }
}