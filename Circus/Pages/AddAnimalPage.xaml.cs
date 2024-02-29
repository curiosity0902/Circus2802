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
    /// Логика взаимодействия для AddAnimalPage.xaml
    /// </summary>
    public partial class AddAnimalPage : Page
    {
        public static List<AnimalTrainer> animalTrainers { get; set; }
        public static List<Cell> cells { get; set; }
        public static List<Gender> genders { get; set; }

        public static Cell cell = new Cell();
        public AddAnimalPage()
        {
            InitializeComponent();
            cells = DBConnection.circussEntities.Cell.ToList();
            genders = DBConnection.circussEntities.Gender.ToList();
            animalTrainers = DBConnection.circussEntities.AnimalTrainer.ToList();
            this.DataContext = this;
        }
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);

        }


        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = GenderCB.SelectedItem as Gender;
                var b = AnimalTrainerCB.SelectedItem as AnimalTrainer;
                StringBuilder error = new StringBuilder();

                if (string.IsNullOrWhiteSpace(FoodTB.Text) || string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(RecommendationTB.Text) ||
                        DateOfBirthDP.SelectedDate == null || string.IsNullOrWhiteSpace(WeightTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }

                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }

                else
                {
                    cell.Recommendations = RecommendationTB.Text.Trim();
                    cell.Name = NameTB.Text.Trim();
                    cell.AgeDate = DateOfBirthDP.SelectedDate;
                    cell.FoodPreferences = FoodTB.Text.Trim();
                    cell.Weight = int.Parse(WeightTB.Text.Trim());
         
                    
                    cell.IDGender = a.IDGender;
                    cell.IDAnimalTrainer = b.IDAnimalTrainer;

                    DBConnection.circussEntities.Cell.Add(cell);
                    DBConnection.circussEntities.SaveChanges();
                    NavigationService.Navigate(new AllAnimalPage());
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
