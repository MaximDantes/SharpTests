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
    public partial class TestWindow : Window
    {
        Test test;

        public TestWindow()
        {
            InitializeComponent();

            testButton.Click += AddTest;
        }
        public TestWindow(Test test) : this()
        {
            this.test = test;

            titleTextBox.Text = test.Title;
            levelTextBox.Text = Convert.ToString(test.Level);

            DataAcces.GetQuestions(test.Id);
            questionsGrid.ItemsSource = test.Questions;

            testButton.Click -= AddTest;
            testButton.Click += EditTest;
        }

        void EditTest(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(titleTextBox.Text) && !String.IsNullOrEmpty(levelTextBox.Text))
            {
                DataAcces.EditTest(test.Id, titleTextBox.Text, Convert.ToInt32(levelTextBox.Text));
                this.Close();
            }
        }
        void AddTest(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(titleTextBox.Text) && !String.IsNullOrEmpty(levelTextBox.Text))
            {
                DataAcces.AddTest(titleTextBox.Text, Convert.ToInt32(levelTextBox.Text));
                this.Close();
            }

        }

        private void addQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            AnswersWIndow answersWIndow = new AnswersWIndow(test.Id);
            this.Hide();
            answersWIndow.ShowDialog();
            questionsGrid.Items.Refresh();
            this.Show();
        }

        private void deleteTestButton_Click(object sender, RoutedEventArgs e)
        {
            if (questionsGrid.SelectedItem != null)
            {
                DataAcces.DeleteQuestion(((Question)questionsGrid.SelectedItem).Id, test.Id);
                questionsGrid.Items.Refresh();
            }
        }

        private void questionsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (questionsGrid.SelectedItem != null)
            {
                AnswersWIndow answersWIndow = new AnswersWIndow((Question)questionsGrid.SelectedItem);
                this.Hide();
                answersWIndow.ShowDialog();
                questionsGrid.Items.Refresh();
                this.Show();
            }
        }
    }
}
