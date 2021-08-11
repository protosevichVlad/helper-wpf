using System;
using System.Collections.Generic;
using HelperWPF.Repositories;
using HelperWPF.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using HelperWPF.Infrastructure.Commands;
using HelperWPF.ViewModel.Models;
using HelperWPF.ViewModel.Base;

namespace HelperWPF.ViewModel.Windows
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private static AppService appService = null;
        private static WeatherService weatherService = null;
        private static NewsService newsService = null;
        private WeatherViewModel currentWeather = new WeatherViewModel();
        private List<WeatherViewModel> forecastWeather = new List<WeatherViewModel>();
        private List<NewsViewModel> news = new List<NewsViewModel>();
        private string today = $"Today {DateTime.Now.Date:dddd d MMMM yyyy}";

        static MainWindowViewModel()
        {
            appService = new AppService();
            weatherService = new WeatherService(new OpenWeatherMapRepository(appService.Location));
            newsService = new NewsService(new NewsRepository(appService.UrlNews));
        }

        public MainWindowViewModel()
        {
            OpenNewsCommand = new OpenNews(OnOpenNewsCommandExecuted, CanOpenNewsCommandExecuted);
        }

        public string Today
        {
            get => today;
        }

        public List<WeatherViewModel> ForecastWeather
        {
            get => Task.Run(() => weatherService.GetDailyWeather()).Result.GetRange(0, 5);
        }

        public WeatherViewModel CurrentWeather
        {
            get => Task.Run(() => weatherService.GetCurrentWeather()).Result;
        }

        public List<NewsViewModel> News
        {
            get => Task.Run(() => newsService.GetAllNews()).Result;
        }

        public ICommand OpenNewsCommand { get; }

        private bool CanOpenNewsCommandExecuted(object parameter) => true;
        private void OnOpenNewsCommandExecuted(object parameter)
        {
            System.Diagnostics.Process.Start((string)parameter);
        }
    }
}