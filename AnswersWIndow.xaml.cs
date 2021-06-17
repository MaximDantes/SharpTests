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
        public AnswersWIndow()
        {
            InitializeComponent();

            answersButton.Click += AddAnswer;
        }
        public AnswersWIndow(Question question) : this()
        {
            this.question = question;

            questionTextBox.Text = question.Text;
            answersGrid.ItemsSource = question.Answers;

            answersButton.Click -= AddAnswer;
            answersButton.Click += EditAnswer;
        }

        void EditAnswer(object sender, RoutedEventArgs e)
        {

        }
        void AddAnswer(object sender, RoutedEventArgs e)
        {

        }

        private void addAnswertButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteAnswerButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
