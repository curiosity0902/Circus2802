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
    /// Логика взаимодействия для EditSheduleArtistPage.xaml
    /// </summary>
    public partial class EditSheduleArtistPage : Page
    {
        public static List<SheduleArtist> sheduleArtists { get; set; }
        public static List<Artist> artists { get; set; }
        public static List<Perfomance> perfomances { get; set; }
        //public static Worker loggedWorker;

        SheduleArtist contextSheduleArtist;
        public EditSheduleArtistPage(SheduleArtist sheduleArtist)
        {
            InitializeComponent();
            artists = DBConnection.circussEntities.Artist.ToList();
            perfomances = DBConnection.circussEntities.Perfomance.ToList();
            sheduleArtists = DBConnection.circussEntities.SheduleArtist.ToList();

            contextSheduleArtist = sheduleArtist;
            this.DataContext = this;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = ArtistCb.SelectedItem as Artist;
                var b = PerfomanceCb.SelectedItem as Perfomance;
                StringBuilder error = new StringBuilder();

                if (string.IsNullOrWhiteSpace(ArtistCb.Text) || string.IsNullOrWhiteSpace(PerfomanceCb.Text) || string.IsNullOrWhiteSpace(DateDP.Text) || string.IsNullOrWhiteSpace(TimeTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }

                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    var existingShedule = DBConnection.circussEntities.SheduleArtist.FirstOrDefault(s => s.IDSheduleArtist == contextSheduleArtist.IDSheduleArtist);

                    DateTime d = (DateTime)DateDP.SelectedDate;
                    int hour = int.Parse(TimeTB.Text.Split(':')[0]);
                    int minute = int.Parse(TimeTB.Text.Split(':')[1]);
                    DateTime dateTime = new DateTime(d.Year, d.Month, d.Day, hour, minute, 0);
                    existingShedule.Date = dateTime;
                    existingShedule.IDArtist = a.IDArtist;
                    existingShedule.IDPerfomance = b.IDPerfomance;
                    DBConnection.circussEntities.SaveChanges();
                    NavigationService.Navigate(new AllArtistShedule());
                }

            }
            catch
            {
                MessageBox.Show("Ой, какая-то ошибка");
            }
        }   
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllArtistShedule());
        }
    }
}
