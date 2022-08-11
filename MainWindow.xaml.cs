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
using System.Windows.Threading;

namespace Watch_Precision
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            watchTime.Text = DateTime.Now.ToShortTimeString();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            pcTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void timeUpButton_Click(object sender, RoutedEventArgs e)
        {
            watchTime.Text = DateTime.Parse(watchTime.Text).AddMinutes(1).ToShortTimeString();
        }

        private void timeDownButton_Click(object sender, RoutedEventArgs e)
        {
            watchTime.Text = DateTime.Parse(watchTime.Text).AddMinutes(-1).ToShortTimeString();
        }
    }
}
