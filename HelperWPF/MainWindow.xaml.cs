using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
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
            
            CurrentTemperature.Content = weather[0].Temp.ToString();
            
        }
    }
}