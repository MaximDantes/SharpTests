﻿using System;
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
            if (!String.IsNullOrEmpty(loginTextBox.Text) && !String.IsNullOrEmpty(passwordTextBox.Password))
                if (DataAcces.SignIn(loginTextBox.Text, passwordTextBox.Password))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
        }
        void SignUp()
        {
            //TODO captcha
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
                    MessageBox.Show("Такой логин уже существует");
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
    }
}
