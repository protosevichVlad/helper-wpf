﻿using System.Windows;

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

            CurrentTemperature.Content = "+20";
        }
    }
}