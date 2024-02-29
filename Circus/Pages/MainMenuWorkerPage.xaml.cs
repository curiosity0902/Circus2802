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
    /// Логика взаимодействия для MainMenuWorkerPage.xaml
    /// </summary>
    public partial class MainMenuWorkerPage : Page
    {

        public static List<Admin> admins { get; set; }
        public static List<Worker> workers { get; set; }
        public static List<DB.Task> tasks { get; set; }

        public static Worker loggedUser;
        public MainMenuWorkerPage()
        {
            InitializeComponent();
            admins = new List<Admin>(DBConnection.circussEntities.Admin.ToList());
            loggedUser = DBConnection.loginedWorker;
            workers = new List<Worker>(DBConnection.circussEntities.Worker.ToList());
            tasks = new List<DB.Task>(DBConnection.circussEntities.Task.Where(x => x.IDWorker == loggedUser.IDWorker && x.Done != true).ToList());
            //TaskLV.ItemsSource = tasks;
            this.DataContext = this;
            Refresh();            
        }
        private void Refresh()
        {
            TaskLV.ItemsSource = DBConnection.circussEntities.Task.ToList();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var existingShedule = DBConnection.circussEntities.Task.FirstOrDefault(s => s.IDWorker == loggedUser.IDWorker);
            if (TaskLV.SelectedItems.Count > 0)
            {
                DataRowView row = TaskLV.SelectedItem as DataRowView; // Получаем выбранную строку как DataRowView

                if (row != null)
                {
                    string textFromColumn2 = row["Комментарий"].ToString(); // Получаем значение из столбца "Column2"

                    // Далее вы можете использовать textFromColumn2 в вашем коде
                    existingShedule.Comment = textFromColumn2;
                    DBConnection.circussEntities.SaveChanges();
                }

            }
            existingShedule.Done = true;
            DBConnection.circussEntities.SaveChanges();
            NavigationService.Navigate(new MainMenuWorkerPage());
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutorizationPage());
        }
    }
}
