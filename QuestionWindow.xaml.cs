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
    public partial class QuestionWindow : Window
    {
        public QuestionWindow()
        {
            Data.CurrentQuestion = new Question()
            {
                Id = 1,
                Text = "question",
                Answers = new Dictionary<string, bool>()
            };
            Data.CurrentQuestion.Answers.Add("correct", true);
            Data.CurrentQuestion.Answers.Add("incorrect 1", false);
            Data.CurrentQuestion.Answers.Add("incorrect 2", false);
            Data.CurrentQuestion.Answers.Add("incorrect 3", false);

            InitializeComponent();

            tabControl.SelectedIndex = 1;


            FillAnswers();
        }

        void FillAnswers()
        {
            questionText.Text = Data.CurrentQuestion.Text;

            foreach (var item in Data.CurrentQuestion.Answers)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
