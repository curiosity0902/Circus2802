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
    /// Логика взаимодействия для AddApplicationPage.xaml
    /// </summary>
    public partial class AddApplicationPage : Page
    {
        public static List<Admin> admins { get; set; }
        public static Artist loggedUser;
        public static List<Artist> artists { get; set; }
        public static List<DB.Application> applications { get; set; }
        public static DB.Application app = new DB.Application();
        public AddApplicationPage()
        {
            InitializeComponent();
            admins = new List<Admin>(DBConnection.circussEntities.Admin.ToList());
            loggedUser = DBConnection.loginedArtist;
            artists = new List<Artist>(DBConnection.circussEntities.Artist.ToList());
            applications = new List<DB.Application>(DBConnection.circussEntities.Application.ToList());
            this.DataContext = this;
        }

        private void AddApplicatBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = AdminCB.SelectedItem as Admin;
                StringBuilder error = new StringBuilder();

                if (string.IsNullOrWhiteSpace(AdminCB.Text) || string.IsNullOrWhiteSpace(DescripTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }

                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    app.IDArtist = loggedUser.IDArtist;
                    app.IDAdmin = a.IDAdmin;
                    app.Description = DescripTB.Text.Trim();
                    app.Done = false;
                    DBConnection.circussEntities.Application.Add(app);
                    DBConnection.circussEntities.SaveChanges();
                    NavigationService.GoBack();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
    
}
