using Money.car;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
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
using System.Windows.Shapes;

namespace Money
{
    /// <summary>
    /// Логика взаимодействия для mainPage.xaml
    /// </summary>
    public partial class mainPage : Window
    {
        AppContextVehicle db;
        public mainPage()
        {
            InitializeComponent();


            db = new AppContextVehicle();
            List<Vehicle> vehicles = db.Vehicles.ToList();
            ListDataUsers.ItemsSource = vehicles;
            
        }

        private void CabinetClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("error");
        }

        private void ExitAccClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы успешно вышли с аккаунта.");
            AuthOrRegWindow authOrRegWindow = new AuthOrRegWindow();
            authOrRegWindow.Show();
            this.Close();
            
        }

        private void AddCarClick(object sender, RoutedEventArgs e)
        {
            car.addCar addCar = new car.addCar();
            addCar.Show();
            this.Close();
        }

        private void ClickEditCar(object sender, MouseButtonEventArgs e)
        {

        }

        private void RefreshBase(object sender, RoutedEventArgs e)
        {
            List<Vehicle> vehicles = db.Vehicles.ToList();
            ListDataUsers.ItemsSource = vehicles;
        }

        private void RemoveCar(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Vehicle vehicle = ListDataUsers.SelectedItem as Vehicle;
                db.Vehicles.Remove(vehicle);
                db.SaveChanges();
                List<Vehicle> vehicles = db.Vehicles.ToList();
                ListDataUsers.ItemsSource = vehicles;
            }catch(ArgumentNullException)
            {
                MessageBox.Show("Выберите объект для удаления.");
            }
        }
    }
}
