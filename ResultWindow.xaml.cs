using LiveCharts;
using LiveCharts.Wpf;
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
    public partial class ResultWindow : Window
    {
        public ResultWindow(int correctCount, int semicorrectCount, int incorrectCount, double time)
        {
            InitializeComponent();

            timeTextBox.Text = Convert.ToString(time) + " c";

            //TODO colors
            //pieChart.SeriesColors = new ColorsCollection() { Colors.Green, Colors.Yellow, Colors.Red };  33,149,242     254,192,7     243,67,54

            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;

            if (correctCount == 0)
                correct.Visibility = Visibility.Collapsed;
            if (semicorrectCount == 0)
                semicorrect.Visibility = Visibility.Collapsed;
            if (incorrectCount == 0)
                incorrect.Visibility = Visibility.Collapsed;

            correct.Values = new ChartValues<int>() { correctCount };
            incorrect.Values = new ChartValues<int>() { incorrectCount };
            semicorrect.Values = new ChartValues<int>() { semicorrectCount };
        }
        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 4;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
