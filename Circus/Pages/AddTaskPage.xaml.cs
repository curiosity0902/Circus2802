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
    /// Логика взаимодействия для AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : Page
    {
        public static List<Admin> admins { get; set; }
        public static Admin loggedUser;
        public static List<Worker> workers { get; set; }
        public static List <DB.Task> tasks { get; set; }

        public static DB.Task task = new DB.Task();
        public AddTaskPage()
        {
            InitializeComponent();
            admins = new List<Admin>(DBConnection.circussEntities.Admin.ToList());
            loggedUser = DBConnection.loginedAdmin;
            workers = new List<Worker>(DBConnection.circussEntities.Worker.ToList());
            tasks = new List<DB.Task>(DBConnection.circussEntities.Task.ToList());
            this.DataContext = this;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = WorkerCB.SelectedItem as Worker;
                StringBuilder error = new StringBuilder();

                if (string.IsNullOrWhiteSpace(WorkerCB.Text) || string.IsNullOrWhiteSpace(DecriptionTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }

                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    task.IDAdmin = loggedUser.IDAdmin;
                    task.IDWorker = a.IDWorker;
                    task.Description = DecriptionTB.Text.Trim();
                    task.Done = false;
                    //task.Comment = false;
                    DBConnection.circussEntities.Task.Add(task);
                    DBConnection.circussEntities.SaveChanges();
                    NavigationService.Navigate(new MainMenuAdmin());
                }
            }
            catch
            {
                MessageBox.Show("Ошибка. ");
            }
        }
    }
}
