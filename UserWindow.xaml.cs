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
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();

            loginTextBox.Text = Data.CurrentUser.Login;
        }

        private void userButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(passwordTextBox.Password) && passwordTextBox.Password == repeatedPasswordTextBox.Password)
            {
                if (!String.IsNullOrEmpty(loginTextBox.Text))
                {
                    if (DataAcces.EditUser(Data.CurrentUser.Id, loginTextBox.Text, passwordTextBox.Password))
                        this.Close();
                    else
                    {
                        loginTextBox.Text = String.Empty;
                        passwordTextBox.Password = String.Empty;
                        repeatedPasswordTextBox.Password = String.Empty;
                        MessageBox.Show("Такой логин уже существует");
                    }
                }
            }
            else
            {
                passwordTextBox.Password = String.Empty;
                repeatedPasswordTextBox.Password = String.Empty;
                MessageBox.Show("Проверьте правильность ввода пароля");
            }
        }
    }
}
