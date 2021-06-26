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

        public TaskWindow()
        {
            InitializeComponent();

            string header =
                "using System;\n" +
                "using System.IO;\n" +
                "using System.Net;\n" +
                "using System.Threading;\n" +
                "using System.Collections.Generic;\n" +
                "using System.Text;\n" +
                "using System.Text.RegularExpressions;\n" +
                //"using System.ComponentModel;\n" +
                "using System.Data;\n\n" +
                //"using System.Drawing;\n" +
                //"using System.Diagnostics;\n" +
                //"using System.Linq;\n" +
                //"using System.Windows.Forms;\n" +
                //"using System.Threading;\n" +
                //"using System.Threading.Tasks;\n\n" +
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

            input.Text = $"{header}\n\n{footer}";

            sharpExecuter = new SharpExecuter();
            SharpExecuter.OnExecute += Log;
        }

        void Log(object message)
        {
            output.Text += message;
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
    }
}
