using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using HelperWPF.Services;
using HelperBLL.Interfaces;
using HelperBLL.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using HelperBLL.Models;
using HelperWPF.Infrastructure.Commands;
using HelperWPF.ViewModel.Models;
using HelperWPF.ViewModel.Base;
using Location = HelperBLL.Models.Location;

namespace HelperWPF.ViewModel.Windows
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private static AppService appService = null;
        private static IWeatherService weatherService = null;
        private static INewsService newsService = null;
        private readonly static IMapper _mapper;
        private WeatherViewModel currentWeather = new WeatherViewModel();
        private List<WeatherViewModel> forecastWeather = new List<WeatherViewModel>();
        private List<NewsViewModel> news = new List<NewsViewModel>();
        private string today = $"Today {DateTime.Now.Date:dddd d MMMM yyyy}";

        static MainWindowViewModel()
        {
            _mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Weather, WeatherViewModel>();
                cfg.CreateMap<News, NewsViewModel>();
                cfg.CreateMap<HelperWPF.ViewModel.Models.Location, HelperBLL.Models.Location>();
            }).CreateMapper();
            appService = new AppService();
            weatherService = new WeatherService(_mapper.Map<HelperWPF.ViewModel.Models.Location, HelperBLL.Models.Location>(appService.Location));
            newsService = new NewsService(appService.UrlNews);
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
            get
            {
                var weathers = Task.Run(() => weatherService.GetDailyWeather()).Result.GetRange(0, 5);
                return _mapper.Map<List<Weather>, List<WeatherViewModel>>(weathers);
            }
        }

        public WeatherViewModel CurrentWeather
        {
            get
            {
                var weather = Task.Run(() => weatherService.GetCurrentWeather()).Result;
                return _mapper.Map<Weather, WeatherViewModel>(weather);
            }
        }

        public List<NewsViewModel> News
        {
            get
            {
                var newsList = Task.Run(() => newsService.GetAllNews()).Result;
                return _mapper.Map<List<News>, List<NewsViewModel>>(newsList);
            }
        }

        public ICommand OpenNewsCommand { get; }

        private bool CanOpenNewsCommandExecuted(object parameter) => true;
        private void OnOpenNewsCommandExecuted(object parameter)
        {
            var url = (string)parameter;
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}