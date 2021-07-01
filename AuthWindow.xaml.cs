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

        void SignIn()
        {
            string authResult = DataAcces.SignIn(loginTextBox.Text, passwordTextBox.Password);

            if (!String.IsNullOrEmpty(loginTextBox.Text) && !String.IsNullOrEmpty(passwordTextBox.Password))
                if (authResult == "user")
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    if (authResult == "admin")
                    {
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageWindow messageWindow = new MessageWindow("Неправильный логин или пароль");
                        messageWindow.ShowDialog();
                    }
                }
        }
        void SignUp()
        {
            if (!String.IsNullOrEmpty(newLoginTextBox.Text) && !String.IsNullOrEmpty(newPasswordTextBox.Password)
                && newPasswordTextBox.Password == RepeatedPasswordTextBox.Password)
                if (DataAcces.SignUp(newLoginTextBox.Text, newPasswordTextBox.Password))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageWindow messageWindow = new MessageWindow("Такой логин уже существует");
                    messageWindow.ShowDialog();
                }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }
        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void signUpConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            SignUp();
        }
        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            SignIn();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && tabControl.SelectedIndex == 0)
                SignIn();
        }
    }
}
