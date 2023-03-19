using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Money.car
{
    /// <summary>
    /// Логика взаимодействия для addCar.xaml
    /// </summary>
    public partial class addCar : Window
    {
        AppContextVehicle db;
        public addCar()
        {
            InitializeComponent();

            db = new AppContextVehicle();
        }

        private void AddCarClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            
            var carFirm = tbCarFirm.Text.Trim();
            var carName = tbCarName.Text.Trim();
            var carYear = tbCarYear.Text.Trim();
            var carStreght = tbCarStreght.Text.Trim();
            var carCase = cbCarCase.Text.Trim();
            var carCoutry = cbCarCountry.Text.Trim();


            if(string.IsNullOrWhiteSpace(carFirm) || string.IsNullOrWhiteSpace(carName) || string.IsNullOrWhiteSpace(carYear) || string.IsNullOrWhiteSpace(carStreght) || string.IsNullOrWhiteSpace(carCase) || string.IsNullOrWhiteSpace(carCoutry))
            {
                MessageBox.Show("Вы заполнили не все данные!");
            }else{
                Vehicle vehicle = new Vehicle(carName, carFirm, carYear, carStreght, carCase, carCoutry);

                db.Vehicles.Add(vehicle);
                db.SaveChanges();

                MessageBox.Show("Данные внесены, спасибо за информацию!");
                mainPage mainpage = new mainPage();
                mainpage.Show();
                this.Close();
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            mainPage mainpage = new mainPage();
            if (Visibility == Visibility.Visible)
            {
                AppContextVehicle.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                mainpage.ListDataUsers.ItemsSource = AppContextVehicle.GetContext().Vehicles.ToList();
            }
        }
    }
}
