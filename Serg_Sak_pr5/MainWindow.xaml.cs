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

        private void Auth_Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Login_Box.Text) || string.IsNullOrEmpty(Password_Box.Text))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            using (var db = new Entities())
            {
                var user = db.User
                    .AsNoTracking()
                    .FirstOrDefault(u->u.Login-- Login_Box.Text && u.Password-- Password_Box.Text);

                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return;
                }
            }
        }
    }
}
