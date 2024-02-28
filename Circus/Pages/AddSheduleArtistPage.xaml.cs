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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Circus.DB;

namespace Circus.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddSheduleArtistPage.xaml
    /// </summary>
    public partial class AddSheduleArtistPage : Page
    {
        public static List<SheduleArtist> sheduleArtists { get; set; }
        public static List<Artist> artists { get; set; }
        public static List<Perfomance> perfomances { get; set; }

        public static SheduleArtist sheduleArtist = new SheduleArtist();
        public AddSheduleArtistPage()
        {
            InitializeComponent();
            artists = DBConnection.circussEntities.Artist.ToList();
            perfomances = DBConnection.circussEntities.Perfomance.ToList();
            sheduleArtists = DBConnection.circussEntities.SheduleArtist.ToList();
            this.DataContext = this;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (DateDP.SelectedDate == null || TimeTb.Text.Trim() == "" ||                    
                    PerfomanceCb.SelectedIndex == -1 || ArtistCb.SelectedIndex == -1)
                {
                    error.AppendLine("Заполните все поля");
                }
                if (ArtistCb.SelectedIndex == -1)
                {
                    error.AppendLine("Выберите артиста");
                }

                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {                 
                    DateTime d = (DateTime)DateDP.SelectedDate;
                    int hour = int.Parse(TimeTb.Text.Split(':')[0]);
                    int minute = int.Parse(TimeTb.Text.Split(':')[1]);
                    DateTime dateTime = new DateTime(d.Year, d.Month, d.Day, hour, minute, 0);
                    sheduleArtist.Date = dateTime;

                    var a = ArtistCb.SelectedItem as Artist;
                    sheduleArtist.IDArtist = a.IDArtist;

                    var b = PerfomanceCb.SelectedItem as Perfomance;
                    sheduleArtist.IDPerfomance = b.IDPerfomance;
                  
                    DBConnection.circussEntities.SheduleArtist.Add(sheduleArtist);
                    DBConnection.circussEntities.SaveChanges();
                    NavigationService.Navigate(new AllArtistShedule());
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllArtistShedule());
        }
    }
}
