﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Circus.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenuAnimalTrainerPage.xaml
    /// </summary>
    public partial class MainMenuAnimalTrainerPage : Page
    {
        public MainMenuAnimalTrainerPage()
        {
            InitializeComponent();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutorizationPage());
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
