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

namespace _01_Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double memory;
        double operand_b;
        Dictionary<char, Func<double, double, double>> mathFunctions;
        Func<double, double, double> selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            memory = 0;
            operand_b = 0;
            mathFunctions = new Dictionary<char, Func<double, double, double>>();
            mathFunctions.Add('+', (x, y) => x + y);
            mathFunctions.Add('-', (x, y) => x - y);
            mathFunctions.Add('*', (x, y) => x * y);
            mathFunctions.Add('/', (x, y) => x / y);
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var btn = e.Source as Label;
            if (btn != null && char.IsDigit(btn.Content.ToString()[0]))
            {
                //number
                memory *= 10;
                memory += double.Parse(btn.Content.ToString());
                lb_display.Content = memory;
            }
            else if (btn != null && mathFunctions.Keys.Contains(btn.Content.ToString()[0]))
            {
                //operator in mathfunctions delegate
                selectedOperator = mathFunctions[btn.Content.ToString()[0]];
                operand_b = memory;
                memory = 0;
                lb_display.Content = memory;
            }
            else if (btn != null && btn.Content.ToString()[0] == 'C')
            {
                //Clear
                operand_b = 0;
                memory = 0;
                lb_display.Content = memory;
            }
            else if (btn != null && btn.Content.ToString()[0] == '=')
            {
                //Calculate
                if (selectedOperator != null)
                {
                    memory = selectedOperator(operand_b, memory);
                    lb_display.Content = memory;
                }
            }
        }
    }
}
