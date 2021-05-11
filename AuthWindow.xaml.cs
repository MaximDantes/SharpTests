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
using System.Windows.Shapes;

namespace SharpTests
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void singUpButton_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void singInButton_Click(object sender, RoutedEventArgs e)
        {
            SignIn();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            string nickname = nicknameBox.Text;
            string login = newLoginBox.Text;
            string password = newPasswordBox.Password;
            string repeatedPassword = repeatePasswordBox.Password;

            bool res = DataAcces.AddUser(nickname, login, password);

            if (!res)
            {
                MessageBox.Show("Такой логин уже существует");
            }
            else
            {
                SignIn();
            }

        }

        void SignIn()
        {

        }
    }
}
