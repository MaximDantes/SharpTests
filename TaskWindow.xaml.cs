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
    public partial class TaskWindow : Window
    {
        SharpExecuter sharpExecuter;

        Test test;

        int currentQuestion;

        int time;

        public TaskWindow(Test test)
        {
            this.test = test;

            DataAcces.GetQuestions(test.Id);

            InitializeComponent();

            ShowTime();

            ShowQuestion(0);
        }

        void ShowQuestion(int questionIndex)
        {
            if (currentQuestion < test.Questions.Count - 1)
            {
                questionTextBlock.Text = test.Questions[questionIndex].Text;
                currentQuestion = questionIndex;

                string header =
                    "using System;\n" +
                    "using System.IO;\n" +
                    "using System.Net;\n" +
                    "using System.Threading;\n" +
                    "using System.Collections.Generic;\n" +
                    "using System.Text;\n" +
                    "using System.Text.RegularExpressions;\n" +
                    "using System.Data;\n\n" +
                    "namespace SharpTests\n" +
                    "{\n" +
                    "   public class Program\n" +
                    "   {\n" +
                    "      public static void Main()\n" +
                    "      {\n";
                string footer =
                    "      }\n" +
                    "   }\n" +
                    "}\n";

                input.Text = $"{header}\n{footer}";

                sharpExecuter = new SharpExecuter();
                SharpExecuter.OnExecute += Log;
            }
            else
            {
                DataAcces.CompleteTest(test.Id, time / 10.0);

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();

                MessageWindow messageWindow = new MessageWindow($"Задания завершены за {time / 10.0} c");
                messageWindow.ShowDialog();
            }
        }

        void Log(object message)
        {
            output.Text += message;
        }

        async void ShowTime()
        {
            while (true)
            {
                time++;

                timeTextBox.Text = Convert.ToString(time / 10.0);

                await Task.Delay(100);
            }
        }

        void Run()
        {
            string code = input.Text;
            output.Text = String.Empty;
            sharpExecuter.Execute(code);
        }

        private void runButton_Click(object sender, RoutedEventArgs e)
        {
            Run();
        }

        private void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            ShowQuestion(currentQuestion + 1);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
