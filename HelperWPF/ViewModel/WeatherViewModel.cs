using System;

namespace HelperWPF.ViewModel
{
    public class WeatherViewModel
    {
        
        public double Temp { get; set; }
        
        public double FeelsLike { get; set; }
        
        public string Description { get; set; }
        
        public string Icon { get; set; }
        
        public DateTime Date { get; set; }
        public string UrlIcon(int scale) => $"http://openweathermap.org/img/wn/{Icon}@{scale}x.png";
    }
}