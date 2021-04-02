namespace HelperWPF.ViewModel
{
    public class CurrentWeatherViewModel
    {
        
        public double Temp { get; set; }
        
        public double FeelsLike { get; set; }
        
        public string Description { get; set; }
        
        public string UrlIcon {
            get
            {
                return $"http://openweathermap.org/img/wn/{icon}@4x.png";
            } 
        }
        private string icon;

        public CurrentWeatherViewModel(string icon, double temp, double feelsLike, string description)
        {
            this.icon = icon;
            this.Temp = temp;
            this.FeelsLike = feelsLike;
            this.Description = description;
        }
    }
}