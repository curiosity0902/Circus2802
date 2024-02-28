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
    /// Логика взаимодействия для AllAnimalPage.xaml
    /// </summary>
    public partial class AllAnimalPage : Page
    {
        public static List<Cell> cells { get; set; }
        public AllAnimalPage()
        {
            InitializeComponent();
            cells = DBConnection.circussEntities.Cell.ToList();
            this.DataContext = this;
            Refresh();
        }
        private void Refresh()
        {
            AnimalLV.ItemsSource = DBConnection.circussEntities.Cell.ToList();
        }

        private void AddAnimalBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAnimalPage());
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuAdmin());
        }
    }
}
