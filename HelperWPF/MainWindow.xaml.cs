using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HelperWPF.Repositories;
using HelperWPF.Services;

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
            var weatherService = new WeatherService(new DailyWeatherRepository());
            var newsService = new NewsService(new NewsRepository());
            DisplayNews(await newsService.GetAllNews());
            SetCurrentWeather(await weatherService.GetCurrentWeather());
            SetForecastWeather(await weatherService.GetDailyWeather());
        }

        private void SetForecastWeather(List<Weather> weather)
        {
            for (int i = 0; i < Forecast.Children.Count; i++)
            {
                if (Forecast.Children[i] is StackPanel dayStackPanel)
                {
                    SetContentToLabel(dayStackPanel.Children[0] , weather[i + 1].Date.ToString("dd/MM/yyyy (ddd)"));
                    SetContentToImage(dayStackPanel.Children[1], weather[i + 1].GetIconUrl(2));
                    SetContentToLabel(dayStackPanel.Children[2] , $"{weather[i + 1].Temp.ToString(CultureInfo.CurrentCulture)}°C");
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
            SetContentToLabel(CurrentTemperature, $"{weather.Temp.ToString(CultureInfo.CurrentCulture)}°C");
            SetContentToLabel(CurrentWeatherDescription, weather.Description.ToString(CultureInfo.CurrentCulture));
            SetContentToImage(CurrentWeatherImage, weather.GetIconUrl(4));
        }

        private void DisplayNews(List<News> news)
        {
            for (int i = 0; i < news.Count; i++)
            {
                Button newsButton = new Button();
                newsButton.MinHeight = 60;
                newsButton.Tag = news[0].Link;
                newsButton.BorderBrush = new SolidColorBrush(Colors.Black);
                newsButton.Background = new SolidColorBrush(Colors.White);
                newsButton.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(OpenLink));

                TextBlock textBlock = new TextBlock();
                textBlock.Text = news[i].Title;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.TextAlignment = TextAlignment.Center;
                
                newsButton.Content = textBlock;

                NewsPanel.Children.Add(newsButton);
            }
        }

        private void OpenLink(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button)
            {
                System.Diagnostics.Process.Start(button.Tag.ToString());
            }
        }
    }
}