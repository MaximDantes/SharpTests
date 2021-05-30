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
        public MainWindow()
        {
            DataAcces.GetTests();

            InitializeComponent();

            level1.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => ShowTests(1);
            level2.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => ShowTests(2);
            level3.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => ShowTests(3);
            level4.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => ShowTests(4);
            level5.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => ShowTests(5);
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
                border.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => ShowQuestions(Data.LevlelTests[index].Id);

                testsGrid.Children.Add(border);


                TextBlock textBlock = new TextBlock()
                {
                    Text = Data.LevlelTests[i].Title,
                    FontSize = 18,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    Cursor=Cursors.Hand
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
        void ShowTests(int level)
        {
            DataAcces.GetTests(level);

            Render();

            tabControl.SelectedIndex = 1;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }
    }
}
