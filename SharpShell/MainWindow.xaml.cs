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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SharpShell
{

    public partial class MainWindow : Window
    {
        SharpExecuter sharpExecuter;

        public MainWindow()
        {
            InitializeComponent();

            string header = 
                "namespace SharpShell\n" +
                "{\n" +
                "   public class Program\n" +
                "   {\n" +
                "      public static void Main()\n" +
                "      {\n";
            string footer =
                "      }\n" +
                "   }\n" +
                "}\n";

            inputTextBox.Text = $"{header}\n\n{footer}";

            sharpExecuter = new SharpExecuter(new ExecuteLogHandler(Log));
        }

        private void runButton_Click(object sender, RoutedEventArgs e)
        {
            string code = inputTextBox.Text;
            sharpExecuter.Execute(code);
        }

        public void Log(object message)
        {
            outputTextBox.Text = string.Empty;
            outputTextBox.Text += message;
        }
    }
}
