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
    /// Логика взаимодействия для EditSheduleArtistPage.xaml
    /// </summary>
    public partial class EditSheduleArtistPage : Page
    {
        public static List<SheduleArtist> sheduleArtists { get; set; }
        public static List<Artist> artists { get; set; }
        public static List<Perfomance> perfomances { get; set; }
        //public static Worker loggedWorker;

        SheduleArtist contextSheduleArtist;
        private void InitializeDataInPage()
        {
            artists = DBConnection.circussEntities.Artist.ToList();
            perfomances = DBConnection.circussEntities.Perfomance.ToList();
            sheduleArtists = DBConnection.circussEntities.SheduleArtist.ToList();
            this.DataContext = this;
    
            DateDP.SelectedDate = contextSheduleArtist.Date;
            TimeTb.Text = contextSheduleArtist.Time.ToString();
            ArtistCb.SelectedIndex = (int)contextSheduleArtist.IDArtist - 1;
            PerfomanceCb.SelectedIndex = (int)contextSheduleArtist.IDPerfomance - 1;    
        }
        public EditSheduleArtistPage(SheduleArtist sheduleArtist)
        {
            InitializeComponent();
            contextSheduleArtist = sheduleArtist;
            InitializeDataInPage();
            this.DataContext = this;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                SheduleArtist sheduleArtist = contextSheduleArtist;
                if (string.IsNullOrWhiteSpace(TimeTb.Text) ||
                        DateDP.SelectedDate == null)
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    DateDP.SelectedDate = contextSheduleArtist.Date;
                    TimeTb.Text = contextSheduleArtist.Time.ToString();
                    ArtistCb.SelectedIndex = (int)contextSheduleArtist.IDArtist - 1;
                    PerfomanceCb.SelectedIndex = (int)contextSheduleArtist.IDPerfomance - 1;
                    DBConnection.circussEntities.SaveChanges();

                    TimeTb.Text = String.Empty;
                    DateDP = null;
                    ArtistCb.Text = String.Empty;
                    PerfomanceCb.Text = String.Empty;

                    DBConnection.circussEntities.SaveChanges();
                    NavigationService.Navigate(new AllArtistShedule());
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllArtistShedule());
        }
    }
}
