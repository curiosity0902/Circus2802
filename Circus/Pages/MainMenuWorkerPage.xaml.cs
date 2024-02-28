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
    /// Логика взаимодействия для MainMenuWorkerPage.xaml
    /// </summary>
    public partial class MainMenuWorkerPage : Page
    {
        public static List<Admin> admins { get; set; }
        public static List<Worker> workers { get; set; }
        public static List<AnimalTrainer> animalTrainers { get; set; }
        public static List<Artist> artists { get; set; }

        public static Worker loggedWorker;
        public static Admin loggedAdmin;
        public static AnimalTrainer loggedAnimalTrainer;
        public static Artist loggedArtist;
        public MainMenuWorkerPage()
        {
            InitializeComponent();
            loggedWorker = DBConnection.loginedWorker;
            UserTB.Text = DBConnection.loginedWorker.Surname.ToString() + " " + DBConnection.loginedWorker.Name.ToString() + " " + DBConnection.loginedWorker.Patronymic.ToString();
            EmailTB.Text = DBConnection.loginedWorker.Login;

            //loggedAdmin = DBConnection.loginedAdmin;
            //UserTB.Text = DBConnection.loginedAdmin.Surname.ToString() + " " + DBConnection.loginedAdmin.Name.ToString() + " " + DBConnection.loginedAdmin.Patronymic.ToString();
            //EmailTB.Text = DBConnection.loginedAdmin.Login;

            //loggedAnimalTrainer = DBConnection.loginedAnimalTrainer;
            //UserTB.Text = DBConnection.loginedAnimalTrainer.Surname.ToString() + " " + DBConnection.loginedAnimalTrainer.Name.ToString() + " " + DBConnection.loginedAnimalTrainer.Patronymic.ToString();
            //EmailTB.Text = DBConnection.loginedAnimalTrainer.Login;

            //loggedArtist = DBConnection.loginedArtist;
            //UserTB.Text = DBConnection.loginedArtist.Surname.ToString() + " " + DBConnection.loginedArtist.Name.ToString() + " " + DBConnection.loginedArtist.Patronymic.ToString();
            //EmailTB.Text = DBConnection.loginedArtist.Login;

            CheckConditionAndToggleButtonVisibility();
        }


        private void CheckConditionAndToggleButtonVisibility()
        {
            if (loggedWorker.IDRole == 1)
            {
                AddWorkersBTN.Visibility = Visibility.Visible;
                AddAnimalBTN.Visibility = Visibility.Visible;
                AddAnimalTrainerBTN.Visibility = Visibility.Visible;
                AddArtistBTN.Visibility = Visibility.Visible;
                SheduleArtistBTN.Visibility = Visibility.Visible;
                AddTaskBTN.Visibility = Visibility.Visible;// Показать кнопку
            }
            //if (loggedArtist.IDRole == 2)
            //{
            //    WatchSheduleArtistBTN.Visibility = Visibility.Visible; // Показать кнопку
            //}
            else
            {
                WatchSheduleArtistBTN.Visibility = Visibility.Collapsed; // Скрыть кнопку
            }
        }

        private void WorkersBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllWorkersPage());
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutorizationPage());
        }

        private void SheduleArtistBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddArtistBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTaskBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAnimalBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAnimalTrainerBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WatchSheduleArtistBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
