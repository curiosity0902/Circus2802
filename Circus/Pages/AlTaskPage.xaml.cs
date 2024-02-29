using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AlTaskPage.xaml
    /// </summary>
    public partial class AlTaskPage : Page
    {
        public static List<Admin> admins { get; set; }
        public static List<Worker> workers { get; set; }
        public static List<DB.Task> tasks { get; set; }

        public static Admin loggedUser;
        public AlTaskPage()
        {
            InitializeComponent();
            admins = new List<Admin>(DBConnection.circussEntities.Admin.ToList());
            loggedUser = DBConnection.loginedAdmin;
            workers = new List<Worker>(DBConnection.circussEntities.Worker.ToList());
            tasks = new List<DB.Task>(DBConnection.circussEntities.Task.Where(x => x.IDAdmin == loggedUser.IDAdmin && x.Viewed != true).ToList());
            this.DataContext = this;
            TaskLV.ItemsSource = tasks;
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var existingShedule = DBConnection.circussEntities.Task.FirstOrDefault(s => s.IDAdmin == loggedUser.IDAdmin);
            if (TaskLV.SelectedItems.Count > 0)
            {
                DataRowView row = TaskLV.SelectedItem as DataRowView; // Получаем выбранную строку как DataRowView

                if (row != null)
                {

                    existingShedule.Viewed = true;
                    DBConnection.circussEntities.SaveChanges();
                }

            }

            DBConnection.circussEntities.SaveChanges();
            NavigationService.Navigate(new AlTaskPage());
        }
    }
}
