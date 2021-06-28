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

    public partial class TasksWindow : Window
    {
        Question question;
        int testId;
        public TasksWindow(int testId)
        {
            this.testId = testId;

            InitializeComponent();

            questionButton.Click += AddAnswer;
        }
        public TasksWindow(Question question) : this(question.Test.Id)
        {
            this.question = question;

            questionTextBox.Text = question.Text;

            questionButton.Click -= AddAnswer;
            questionButton.Click += EditAnswer;
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
                this.Close();
            }
        }
    }
}

