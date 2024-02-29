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
    /// Логика взаимодействия для AllApplicationPage.xaml
    /// </summary>
    public partial class AllApplicationPage : Page
    {
        public static List<Admin> admins { get; set; }
        public static List<Artist> artists { get; set; }
        public static List<DB.Application> application { get; set; }
        public static Admin loggedUser;
        public AllApplicationPage()
        {
            InitializeComponent();
            admins = new List<Admin>(DBConnection.circussEntities.Admin.ToList());
            artists = new List<Artist>(DBConnection.circussEntities.Artist.ToList());
            loggedUser = DBConnection.loginedAdmin;
            application = new List<DB.Application>(DBConnection.circussEntities.Application.Where(x => x.IDAdmin == loggedUser.IDAdmin && x.Done != true).ToList());

            ApplicationLV.ItemsSource = application;
            this.DataContext = this;
        }

        private void ApplicationLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var existingShedule = DBConnection.circussEntities.Application.FirstOrDefault(s => s.IDAdmin == loggedUser.IDAdmin);


            existingShedule.Done = true;

            DBConnection.circussEntities.SaveChanges();
            NavigationService.Navigate(new AllApplicationPage());
        }
    }
}
