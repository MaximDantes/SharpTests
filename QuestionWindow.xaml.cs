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
    public partial class QuestionWIndow : Window
    {
        int testId;
        int currentQuestionNumber = 0;
        int mistakesCount = 0;
        int semicorrectCount = 0;
        bool isMistaken = false;
        int time = 0;
        List<int> selectedAnswers = new List<int>();
        public QuestionWIndow(int testId)
        {
            this.testId = testId;

            DataAcces.GetQuestions(testId);
            DataAcces.MixAnswers(testId);
            InitializeComponent();

            answerRow1.Height = new GridLength(0, GridUnitType.Star);
            answerRow2.Height = new GridLength(0, GridUnitType.Star);
            answerRow3.Height = new GridLength(0, GridUnitType.Star);
            answerRow4.Height = new GridLength(0, GridUnitType.Star);

            Render();

            ShowTime();
        }

        void Render()
        {
            isMistaken = false;
            selectedAnswers.Clear();



            answerBorder1.BorderBrush = new SolidColorBrush(Color.FromRgb(103, 58, 183));
            answerBorder2.BorderBrush = new SolidColorBrush(Color.FromRgb(103, 58, 183));
            answerBorder3.BorderBrush = new SolidColorBrush(Color.FromRgb(103, 58, 183));
            answerBorder4.BorderBrush = new SolidColorBrush(Color.FromRgb(103, 58, 183));

            this.Title = $"Вопрос {currentQuestionNumber + 1}";

            mistakesTextBox.Text = $"Ошибки: {mistakesCount}";

            progressTextBox.Text = $"{currentQuestionNumber + 1} / {Data.Questions.Count}";

            confirmButton.Content = "Проверить";

            answerRow3.Height = new GridLength(0, GridUnitType.Star);
            answerRow4.Height = new GridLength(0, GridUnitType.Star);

            questionTextBlock.Text = Data.Questions[currentQuestionNumber].Text;

            answerRow1.Height = new GridLength(1, GridUnitType.Star);
            answer1.Text = Data.Questions[currentQuestionNumber].Answers.ElementAt(0).Key;

            answerRow2.Height = new GridLength(1, GridUnitType.Star);
            answer2.Text = Data.Questions[currentQuestionNumber].Answers.ElementAt(1).Key;

            if (Data.Questions[currentQuestionNumber].Answers.Count > 2)
            {
                answerRow3.Height = new GridLength(1, GridUnitType.Star);
                answer3.Text = Data.Questions[currentQuestionNumber].Answers.ElementAt(2).Key;
            }

            if (Data.Questions[currentQuestionNumber].Answers.Count > 3)
            {
                answerRow4.Height = new GridLength(1, GridUnitType.Star);
                answer4.Text = Data.Questions[currentQuestionNumber].Answers.ElementAt(3).Key;
            }
        }
        void ShowNextQuestion()
        {
            if (currentQuestionNumber < Data.Questions.Count - 1)
            {
                currentQuestionNumber++;
                confirmButton.Click += confirmButton_Click;
                confirmButton.Click -= confirmNextButton_Click;
                Render();
            }
            else
            {
                if (mistakesCount == 0 && semicorrectCount == 0)
                    DataAcces.CompleteTest(testId, time / 10);

                ResultWindow resultWindow = new ResultWindow(currentQuestionNumber + 1 - mistakesCount, semicorrectCount, mistakesCount - semicorrectCount, time / 10.0);
                resultWindow.Show();
                this.Close();
            }
        }
        void ValidateQuestion()
        {
            List<Border> answers = new List<Border>();

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(grid); i++)
            {
                if (VisualTreeHelper.GetChild(grid, i) is Border)
                {
                    answers.Add(VisualTreeHelper.GetChild(grid, i) as Border);
                }
            }

            int questionsCorrectAnswersCount = 0;
            List<int> correctSelectedAnswers = new List<int>();

            for (int i = 0; i < Data.Questions[currentQuestionNumber].Answers.Count; i++)
            {
                if (Data.Questions[currentQuestionNumber].Answers.ElementAt(i).Value)
                {
                    answers[i].BorderBrush = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    questionsCorrectAnswersCount++;

                    if (selectedAnswers.Contains(i))
                        correctSelectedAnswers.Add(i);
                }
            }

            for (int i = 0; i < Data.Questions[currentQuestionNumber].Answers.Count; i++)
            {
                if (selectedAnswers.Contains(i) && !Data.Questions[currentQuestionNumber].Answers.ElementAt(i).Value)
                {
                    answers[i].BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));

                    if (!isMistaken)
                        mistakesCount++;
                    isMistaken = true;
                }
            }

            if (selectedAnswers.Count == 0)
            {
                if (!isMistaken)
                    mistakesCount++;
                isMistaken = true;
            }


            if (questionsCorrectAnswersCount > selectedAnswers.Count && correctSelectedAnswers.Count > 0)
            {
                if (!isMistaken)
                    mistakesCount++;

                semicorrectCount++;
            }

            mistakesTextBox.Text = $"Ошибки: {mistakesCount}";

            confirmButton.Content = "Далее";

            confirmButton.Click -= confirmButton_Click;
            confirmButton.Click += confirmNextButton_Click;
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

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            ValidateQuestion();
        }
        private void confirmNextButton_Click(object sender, RoutedEventArgs e)
        {
            ShowNextQuestion();
        }

        private void answerBorder1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (selectedAnswers.Contains(0))
            {
                border.BorderBrush = new SolidColorBrush(Color.FromRgb(103, 58, 183));
                selectedAnswers.Remove(0);
            }
            else
            {
                border.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                selectedAnswers.Add(0);
            }
        }
        private void answerBorder2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (selectedAnswers.Contains(1))
            {
                border.BorderBrush = new SolidColorBrush(Color.FromRgb(103, 58, 183));
                selectedAnswers.Remove(1);
            }
            else
            {
                border.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                selectedAnswers.Add(1);
            }
        }
        private void answerBorder3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (selectedAnswers.Contains(2))
            {
                border.BorderBrush = new SolidColorBrush(Color.FromRgb(103, 58, 183));
                selectedAnswers.Remove(2);
            }
            else
            {
                border.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                selectedAnswers.Add(2);
            }
        }
        private void answerBorder4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (selectedAnswers.Contains(3))
            {
                border.BorderBrush = new SolidColorBrush(Color.FromRgb(103, 58, 183));
                selectedAnswers.Remove(3);
            }
            else
            {
                border.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                selectedAnswers.Add(3);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}