using System;
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
    /// Логика взаимодействия для MainMenuArtist.xaml
    /// </summary>
    public partial class MainMenuArtist : Page
    {
        public static List<SheduleArtist> shedules { get; set; }
        public static List<Artist> artists { get; set; }
        public static List<Perfomance> perfomances { get; set; }

        Artist contextartist;
        public MainMenuArtist(Artist artist)
        {
            InitializeComponent();
            artists = new List<Artist>(DBConnection.circussEntities.Artist.ToList());
            perfomances = new List<Perfomance>(DBConnection.circussEntities.Perfomance.ToList());
            shedules = new List<SheduleArtist>(DBConnection.circussEntities.SheduleArtist.Where(x => x.IDArtist == artist.IDArtist).ToList());
            contextartist = artist;
            SheduleLV.ItemsSource = shedules;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddApplicationPage());
        }
    }
}
