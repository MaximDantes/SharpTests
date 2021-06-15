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
    public partial class StatWindow : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public StatWindow(int userId)
        {
            InitializeComponent();

            List<string> labelsList = new List<string>();

            chart.SeriesColors = new ColorsCollection
            {
                Color.FromRgb(103, 58, 183)
            };

            SeriesCollection = new SeriesCollection();

            ColumnSeries timeColumn = new ColumnSeries
            {
                Title = "Время",
                Values = new ChartValues<double>()
            };

            List<Test> tests = DataAcces.GetCompletedTests(userId);

            foreach (Test item in tests)
            {
                timeColumn.Values.Add(item.Time);
                    labelsList.Add(item.Title);
            }

            SeriesCollection.Add(timeColumn);

            Labels = labelsList.ToArray();
            
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

    }
}
