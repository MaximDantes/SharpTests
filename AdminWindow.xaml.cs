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
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            DataAcces.GetTests();
            DataAcces.GetUsers();

            InitializeComponent();

            testsGrid.ItemsSource = Data.Tests;
            usersGrid.ItemsSource = Data.Users;
        }

        void RefreshGrids()
        {
            testsGrid.Items.Refresh();
            usersGrid.Items.Refresh();
        }
        void FindTest()
        {
            if (String.IsNullOrEmpty(findTestTextBox.Text) && levelComboBox.SelectedIndex == 4)
            {
                testsGrid.ItemsSource = Data.Tests;
            }
            else
            {
                if (!String.IsNullOrEmpty(findTestTextBox.Text) && levelComboBox.SelectedIndex < 4)
                {
                    testsGrid.ItemsSource = Data.Tests.Where(x => x.Title.ToLower().Contains(findTestTextBox.Text.ToLower().Trim()) && x.Level == levelComboBox.SelectedIndex + 1);
                    return;
                }
                if (String.IsNullOrEmpty(findTestTextBox.Text))
                {
                    testsGrid.ItemsSource = Data.Tests.Where(x => x.Level == levelComboBox.SelectedIndex + 1);
                    return;
                }
                if (levelComboBox.SelectedIndex == 4)
                {
                    testsGrid.ItemsSource = Data.Tests.Where(x => x.Title.ToLower().Contains(findTestTextBox.Text.ToLower().Trim()));
                    return;
                }
            }
        }
        void FindUser()
        {
            if (!String.IsNullOrEmpty(findUserTextBox.Text))
                usersGrid.ItemsSource = Data.Users.Where(x => x.Login.ToLower().Contains(findUserTextBox.Text.ToLower()));
            else
                usersGrid.ItemsSource = Data.Users;
        }

        private void deleteTestButton_Click(object sender, RoutedEventArgs e)
        {
            if (testsGrid.SelectedItem != null)
            {
                DataAcces.DeleteTest(((Test)testsGrid.SelectedItem).Id);
            }
            RefreshGrids();
        }

        private void addTestButton_Click(object sender, RoutedEventArgs e)
        {
            TestWindow testWindow = new TestWindow();
            testWindow.ShowDialog();
            RefreshGrids();
        }

        private void testsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (testsGrid.SelectedItem != null)
            {
                TestWindow testWindow = new TestWindow((Test)testsGrid.SelectedItem);
                testWindow.ShowDialog();
                RefreshGrids();
            }
        }

        private void usersGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (usersGrid.SelectedItem != null)
            {
                StatWindow statWindow = new StatWindow(((User)usersGrid.SelectedItem).Id);
                statWindow.ShowDialog();
            }
        }

        private void tab1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void tab2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void findTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindTest();
        }

        private void levelTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FindTest();
        }

        private void findUserTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindUser();
        }
    }
}
