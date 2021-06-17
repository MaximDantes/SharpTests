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
        public AnswerWindow()
        {
            InitializeComponent();

            answerButton.Click += AddAnswer;
        }
        public AnswerWindow(string answer, bool isCorrect) : this()
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

        }

        void EditAnswer(object sender, RoutedEventArgs e)
        {

        }
    }
}
