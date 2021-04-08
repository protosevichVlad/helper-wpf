using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using HelperWPF.Repositories;

namespace HelperWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            SetData();
        }

        private async void SetData()
        {
            var weatherRepository = new DailyWeatherRepository();
            var weather = (await weatherRepository.GetAll()).ToList();

            SetCurrentWeather(weather[0]);
            SetForecastWeather(weather);
        }

        private void SetForecastWeather(List<Weather> weather)
        {
            for (int i = 0; i < Forecast.Children.Count; i++)
            {
                if (Forecast.Children[i] is StackPanel dayStackPanel)
                {
                    SetContentToLabel(dayStackPanel.Children[0] , weather[i + 1].Date.ToString("dd/MM/yyyy (ddd)"));
                    SetContentToImage(dayStackPanel.Children[1], weather[i + 1].GetIconUrl(2));
                    SetContentToLabel(dayStackPanel.Children[2] , weather[i + 1].Temp.ToString(CultureInfo.CurrentCulture));
                }
            }
        }

        private void SetContentToLabel(object obj, string data)
        {
            if (obj is Label label)
            {
                label.Content = data;
            }
        }
        
        private void SetContentToImage(object obj, string url)
        {
            if (obj is Image image)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(url, UriKind.Absolute);
                bitmap.EndInit();

                image.Source = bitmap;
            }
        }

        private void SetCurrentWeather(Weather weather)
        {
            SetContentToLabel(CurrentDate, $"Сегодня {weather.Date:dddd d MMMM yyyy}");
            SetContentToLabel(CurrentTemperature, weather.Temp.ToString(CultureInfo.CurrentCulture));
            SetContentToLabel(CurrentWeatherDescription, weather.Description.ToString(CultureInfo.CurrentCulture));
            SetContentToImage(CurrentWeatherImage, weather.GetIconUrl(4));
        }
    }
}