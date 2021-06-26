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
    public partial class AnswerWindow : Window
    {
        string answer;
        bool isCorrect;
        Question question;
        public AnswerWindow(Question question)
        {
            this.question = question;

            InitializeComponent();

            answerButton.Click += AddAnswer;
        }
        public AnswerWindow(Question question, string answer, bool isCorrect) : this(question)
        {
            this.answer = answer;
            this.isCorrect = isCorrect;

            answerTextBox.Text = answer;
            answerCheckBox.IsChecked = isCorrect;

            answerButton.Click -= AddAnswer;
            answerButton.Click += EditAnswer;
        }

        void AddAnswer(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(answerTextBox.Text))
            {
                DataAcces.AddAnswer(question, answerTextBox.Text, (bool)answerCheckBox.IsChecked);
                this.Close();
            }
        }

        void EditAnswer(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(answerTextBox.Text))
            {

            }
        }
    }
}
