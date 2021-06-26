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
    public partial class MainWindow : Window
    {
        int level = -1;
        public MainWindow()
        {
            DataAcces.GetTests();

            InitializeComponent();

            loginTextBlock.Text = Data.CurrentUser.Login;

            level1.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => ShowTests(1);
            level2.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => ShowTests(2);
            level3.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => ShowTests(3);
            level4.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => ShowTests(4);
            level5.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => ShowTests(5);

            progressTextBlock1.Text = $"{DataAcces.CalcCompletedTestsCount(1)} / {DataAcces.CalcTestsCount(1)}";
            if (DataAcces.CalcTestsCount(1) > 0 && DataAcces.CalcCompletedTestsCount(1) / DataAcces.CalcTestsCount(1) == 1)
                level1.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 255, 0));

            progressTextBlock2.Text = $"{DataAcces.CalcCompletedTestsCount(2)} / {DataAcces.CalcTestsCount(2)}";
            if (DataAcces.CalcTestsCount(2) > 0 && DataAcces.CalcCompletedTestsCount(2) / DataAcces.CalcTestsCount(2) == 1)
                level2.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 255, 0));

            progressTextBlock3.Text = $"{DataAcces.CalcCompletedTestsCount(3)} / {DataAcces.CalcTestsCount(3)}";
            if (DataAcces.CalcTestsCount(3) > 0 && DataAcces.CalcCompletedTestsCount(3) / DataAcces.CalcTestsCount(3) == 1)
                level3.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 255, 0));

            progressTextBlock4.Text = $"{DataAcces.CalcCompletedTestsCount(4)} / {DataAcces.CalcTestsCount(4)}";
            if (DataAcces.CalcTestsCount(4) > 0 && DataAcces.CalcCompletedTestsCount(4) / DataAcces.CalcTestsCount(4) == 1)
                level4.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 255, 0));

            progressTextBlock5.Text = $"{DataAcces.CalcCompletedTestsCount(5)} / {DataAcces.CalcTestsCount(5)}";
            if (DataAcces.CalcTestsCount(5) > 0 && DataAcces.CalcCompletedTestsCount(5) / DataAcces.CalcTestsCount(5) == 1)
                level5.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 255, 0));
        }

        void Render()
        {
            List<int> removeList = new List<int>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(testsGrid); i++)
            {
                if (VisualTreeHelper.GetChild(testsGrid, i) is Border)
                    removeList.Add(i);
            }
            for (int i = 0; i < removeList.Count; i++)
            {
                testsGrid.Children.RemoveAt(removeList[i]);

                for (int j = 0; j < removeList.Count; j++)
                {
                    removeList[j]--;
                }
            }
            testsGrid.RowDefinitions.Clear();
            testsGrid.RowDefinitions.Add(new RowDefinition());

            for (int i = 0; i < Data.LevlelTests.Count; i++)
            {
                testsGrid.RowDefinitions.Add(new RowDefinition());

                Border border = new Border()
                {
                    BorderBrush = new SolidColorBrush(Color.FromRgb(103, 58, 183)),
                    BorderThickness = new Thickness(3),
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(10, 5, 10, 5),
                    Height = 70,
                    Cursor = Cursors.Hand
                };
                if (Data.LevlelTests[i].IsCompleted)
                    border.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                Grid.SetRow(border, i + 1);

                int index = i;

                if (level == 4)
                    border.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => ShowQuestions(Data.LevlelTests[index].Id);
                else
                    border.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => ShowTasks(Data.LevlelTests[index].Id);

                testsGrid.Children.Add(border);


                TextBlock textBlock = new TextBlock()
                {
                    Text = Data.LevlelTests[i].Title,
                    FontSize = 18,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    Cursor = Cursors.Hand
                };
                border.Child = textBlock;
            }
        }

        void ShowQuestions(int testId)
        {
            QuestionWIndow questionWIndow = new QuestionWIndow(testId);
            questionWIndow.Show();
            this.Close();
        }
        void ShowTasks(int testId)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.Show();
            this.Close();
        }
        void ShowTests(int level)
        {
            DataAcces.GetTests(level);

            this.level = level;

            Render();

            tabControl.SelectedIndex = 1;
        }
        void ShowStat()
        {
            StatWindow statWindow = new StatWindow(Data.CurrentUser.Id);
            statWindow.ShowDialog();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void statButton_Click(object sender, RoutedEventArgs e)
        {
            ShowStat();
        }

        private void loginGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.ShowDialog();
            loginTextBlock.Text = Data.CurrentUser.Login;
        }
    }
}
