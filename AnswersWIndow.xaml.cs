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
    public partial class AnswersWIndow : Window
    {
        Question question;
        int testId;
        public AnswersWIndow(int testId)
        {
            this.testId = testId;

            InitializeComponent();

            answersButton.Click += AddAnswer;
        }
        public AnswersWIndow(Question question) : this(question.Test.Id)
        {
            this.question = question;

            questionTextBox.Text = question.Text;
            RefreshGrid();

            answersButton.Click -= AddAnswer;
            answersButton.Click += EditAnswer;
        }

        void RefreshGrid()
        {
            question = Data.Questions.Find(x => x.Id == question.Id);
            answersGrid.ItemsSource = question.Answers;
            answersGrid.Items.Refresh();
        }

        void EditAnswer(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(questionTextBox.Text))
            {
                DataAcces.EditQuestion(question.Id, testId, questionTextBox.Text);
                this.Close();
            }
        }
        void AddAnswer(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(questionTextBox.Text))
            {
                DataAcces.AddQuestion(testId, questionTextBox.Text);
                this.question = Data.Questions[Data.Questions.Count - 1];
                answersButton.Click -= AddAnswer;
                answersButton.Click += EditAnswer;
            }
        }

        private void addAnswertButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.question != null)
            {
                AnswerWindow answerWindow = new AnswerWindow(question);
                answerWindow.ShowDialog();
                RefreshGrid();
            }
            else
            {
                MessageBox.Show("Перед добавлением ответов необходимо сохранить вопрос");
            }
        }

        private void deleteAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (answersGrid.SelectedIndex >= 0)
            {
                DataAcces.DeleteAnswer(question, question.Answers.ElementAt(answersGrid.SelectedIndex).Key, question.Answers.ElementAt(answersGrid.SelectedIndex).Value);
                RefreshGrid();
            }
        }

        private void answersGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (answersGrid.SelectedIndex >= 0)
            {
                AnswerWindow answerWindow = new AnswerWindow(question,
                    question.Answers.ElementAt(answersGrid.SelectedIndex).Key, question.Answers.ElementAt(answersGrid.SelectedIndex).Value);
                answerWindow.ShowDialog();
                RefreshGrid();
            }
        }
    }
}
