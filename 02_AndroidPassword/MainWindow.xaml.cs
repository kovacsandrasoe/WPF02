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

namespace _02_AndroidPassword
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool selection;
        string currentpw = "";
        string secretpw = "684123";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selection = true;
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (currentpw == secretpw)
            {
                MessageBox.Show("SIGNED IN");
            }
            

            selection = false;
            currentpw = "";
            foreach (var item in grid.Children)
            {
                if (item is Ellipse)
                {
                    (item as Ellipse).Fill = Brushes.Blue;
                }
            }
        }

        private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (selection && e.Source!= null && e.Source is Ellipse)
            {
                Ellipse ellipse = e.Source as Ellipse;
                if (!currentpw.Contains(ellipse.Tag as string))
                {
                    currentpw += ellipse.Tag as string;
                    ellipse.Fill = Brushes.Red;
                }
            }
        }

    }
}
