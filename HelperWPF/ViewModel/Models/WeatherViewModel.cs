using System;

namespace HelperWPF.ViewModel.Models
{
    public class WeatherViewModel
    {
        private double _temp;
        private DateTime _date;

        public double FeelsLike { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        public double Temp
        {
            get => _temp;
            set => _temp = Math.Round(value);
        }

        public DateTime Date
        {
            get => _date.Date;
            set => _date = value.Date;
        }

        public string TemperatureStr => $"{_temp}°C";
        public string DateStr => _date.ToString("dd.MM.yyy (ddd)");

        public string UrlIcon1x => UrlIcon(1);
        public string UrlIcon2x => UrlIcon(2);
        public string UrlIcon4x => UrlIcon(4);

        public string UrlIcon(int scale) => $"http://openweathermap.org/img/wn/{Icon}@{scale}x.png";
    }
}