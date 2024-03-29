﻿using System;
using System.Collections.Generic;
using System.Data.Common;
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
using Circus.DB;

namespace Circus.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllArtistShedule.xaml
    /// </summary>
    public partial class AllArtistShedule : Page
    {
        public static List<SheduleArtist> sheduleArtists { get; set; }
        public static List<Artist> artists { get; set; }
        public static List<Perfomance> perfomances { get; set; }
        public AllArtistShedule()
        {
            InitializeComponent();
            sheduleArtists = DBConnection.circussEntities.SheduleArtist.ToList();
            artists = DBConnection.circussEntities.Artist.ToList();
            perfomances = DBConnection.circussEntities.Perfomance.ToList();
            this.DataContext = this;
            Refresh();
        }
        private void Refresh()
        {
            SheduleLV.ItemsSource = DBConnection.circussEntities.SheduleArtist.ToList();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuAdmin());
        }

        private void EditSheduleBTN_Click(object sender, RoutedEventArgs e)
        {
            if (SheduleLV.SelectedItem is SheduleArtist)
            {
                DBConnection.selectedForEditShedule = SheduleLV.SelectedItem as SheduleArtist;
                NavigationService.Navigate(new EditSheduleArtistPage(SheduleLV.SelectedItem as SheduleArtist));
            }
        }

        private void AddSheduleBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSheduleArtistPage());
        }

        private void ArtistCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = ArtistCB.SelectedItem as Artist;
            SheduleLV.ItemsSource = new List<SheduleArtist>(DBConnection.circussEntities.SheduleArtist.Where(x => x.IDArtist == a.IDArtist).ToList());
        }
    }
}
