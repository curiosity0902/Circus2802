using System;
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
using Circus.DB;

namespace Circus.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllWorkersPage.xaml
    /// </summary>
    public partial class AllWorkersPage : Page
    {
        public static List<Admin> admins { get; set; }
        public static List<Worker> workers { get; set; }
        public static List<AnimalTrainer> animalTrainers { get; set; }
        public static List<Artist> artists { get; set; }
        public static List<Role> roles { get; set; }
        public static List<Gender> genders { get; set; }

        public static Worker loggedWorker;
        public static Admin loggedAdmin;
        public static AnimalTrainer loggedAnimalTrainer;
        public static Artist loggedArtist;

        public AllWorkersPage()
        {
            InitializeComponent();
            loggedAdmin = DBConnection.loginedAdmin;
            admins = DBConnection.circussEntities.Admin.ToList();
            workers = DBConnection.circussEntities.Worker.ToList();
            artists = DBConnection.circussEntities.Artist.ToList();
            animalTrainers = DBConnection.circussEntities.AnimalTrainer.ToList();
            this.DataContext = this;
            Refresh();
        }
        private void Refresh()
        {
            WorkersLV.ItemsSource = DBConnection.circussEntities.Worker.ToList();
            ArtistLV.ItemsSource = DBConnection.circussEntities.Artist.ToList();
            AdminLV.ItemsSource = DBConnection.circussEntities.Admin.ToList();
            AnimalTrainerLV.ItemsSource = DBConnection.circussEntities.AnimalTrainer.ToList();
        }
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuAdmin());
        }
    }
}
