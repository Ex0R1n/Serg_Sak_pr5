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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Serg_Sak_pr5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Auth_Button_Click(object sender, RoutedEventArgs e)
        {
            Auth(Login_Box.Text, Password_Box.Text);
        }

        public bool Auth(string login, string password)
        {
            if (string.IsNullOrEmpty(Login_Box.Text) || string.IsNullOrEmpty(Password_Box.Text))
            {
                MessageBox.Show("Введите логин и пароль!");
                return false;
            }

            using (var db = new Entities())
            {
                var user = db.User
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == Login_Box.Text && u.Password == Password_Box.Text);


                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return false;
                }
                else if (Login_Box.Text == user.Login && Password_Box.Text == user.Password)
                {
                    MessageBox.Show($"Здравствуйте, {user.Role} {user.FIO}");
                }
                Login_Box.Clear();
                Password_Box.Clear();

                return true;
            }
        }
      
    }
}
