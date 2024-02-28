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
    /// Логика взаимодействия для MainMenuAdmin.xaml
    /// </summary>
    public partial class MainMenuAdmin : Page
    {
        public static List<Admin> admins { get; set; }
        public static List<Worker> workers { get; set; }
        public static List<AnimalTrainer> animalTrainers { get; set; }
        public static List<Artist> artists { get; set; }
        public static Admin loggedAdmin;
        public MainMenuAdmin()
        {
            InitializeComponent();

            loggedAdmin = DBConnection.loginedAdmin;
            UserTB.Text = DBConnection.loginedAdmin.Surname.ToString() + " " + DBConnection.loginedAdmin.Name.ToString() + " " + DBConnection.loginedAdmin.Patronymic.ToString();
            EmailTB.Text = DBConnection.loginedAdmin.Login;
        }


        private void CheckConditionAndToggleButtonVisibility()
        {
            //if (loggedWorker.IDRole == 1)
            //{
            //    AddWorkersBTN.Visibility = Visibility.Visible;
            //    AddAnimalBTN.Visibility = Visibility.Visible;
            //    AddAnimalTrainerBTN.Visibility = Visibility.Visible;
            //    AddArtistBTN.Visibility = Visibility.Visible;
            //    SheduleArtistBTN.Visibility = Visibility.Visible;
            //    AddTaskBTN.Visibility = Visibility.Visible;// Показать кнопку
            //}
            //if (loggedArtist.IDRole == 2)
            //{
            //    WatchSheduleArtistBTN.Visibility = Visibility.Visible; // Показать кнопку
            //}
            //else
            //{
            //    WatchSheduleArtistBTN.Visibility = Visibility.Collapsed; // Скрыть кнопку
            //}
        }

        private void WorkersBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddWorkerPage());
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutorizationPage());
        }

        private void SheduleArtistBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSheduleArtistPage());
        }

        private void AddTaskBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTaskPage());
        }

        private void AddAnimalBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAnimalPage());
        }

        private void WatchSheduleArtistBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
