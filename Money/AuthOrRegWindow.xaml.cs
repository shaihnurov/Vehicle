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

namespace Money
{
    public partial class AuthOrRegWindow : Window
    {
        AppContext db;
        public AuthOrRegWindow()
        {
            InitializeComponent();
            
            db = new AppContext();
        }

        private void RegClick(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text.Trim();
            string pass = tbPass.Password.Trim();

            if (name.Contains("!") || name.Contains("@") || name.Contains(".") || name.Contains(",") || name.Contains("#") || name.Length < 1)
            {
                MessageBox.Show("Введенны запрещенные символы в поле Имя");
                tbName.Background = Brushes.Pink;
                tbPass.Background = Brushes.Pink;
            }
            else if (pass.Length < 6)
            {
                tbName.Background = Brushes.Transparent;
                MessageBox.Show("Введите пароль больше 6 символов.");
                tbPass.Background = Brushes.Pink;
            }
            else
            {
                tbName.Background = Brushes.Transparent;
                tbPass.Background = Brushes.Transparent;

                User user = new User(name, pass);

                var register_cath = db.Users.Any(b => b.Name == name);
                if (register_cath)
                {
                    MessageBox.Show("Данное имя занято");
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();

                    MessageBox.Show("Успешная регистрация");
                    mainPage Page = new mainPage();
                    Page.Show();
                    Close();
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.IsChecked = Properties.Settings.Default.IsRemember;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsRemember = (bool)checkBox1.IsChecked;
            Properties.Settings.Default.Save();
        }

        private void AuthClick(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text.Trim();
            string pass = tbPass.Password.Trim();

            if (name.Contains("!") || name.Contains("@") || name.Contains(".") || name.Contains(",") || name.Contains("#") || name.Length < 1)
            {
                MessageBox.Show("Введенны запрещенные символы в поле Имя");
                tbName.Background = Brushes.Pink;
                tbPass.Background = Brushes.Pink;
            }
            else if (pass.Length < 6)
            {
                tbName.Background = Brushes.Transparent;
                MessageBox.Show("Введите пароль больше 6 символов.");
                tbPass.Background = Brushes.Pink;
            }
            else
            {
                tbName.Background = Brushes.Transparent;
                tbPass.Background = Brushes.Transparent;

                User authUser = null;

                using (AppContext db = new AppContext())
                {
                    authUser = db.Users.Where(b => b.Name == name && b.Pass == pass).FirstOrDefault();
                }

                if (authUser != null)
                {
                    mainPage Page = new mainPage();
                    Page.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вы ввели не корректные данные для входа в систему.");
                }
            }
        }
    }
}
