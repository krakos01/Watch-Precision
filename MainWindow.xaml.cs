using System;
using System.Windows;
using System.Windows.Threading;
using static Watch_Precision.Watch;
using static Watch_Precision.Database;
using System.Windows.Documents;
using System.Collections.Generic;

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
            Database dbObject = new Database();

            ShowPositions();
            cbWatches.ItemsSource = dbObject.ReadWatchesNames();
            PrevMeasurementsLV.ItemsSource = dbObject.ReadMeasurements();

            DispatcherTimer timer = new();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            watchTime.Text = DateTime.Now.ToShortTimeString();
        }

        void Timer_Tick(object? sender, EventArgs e)
        {
            pcTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void TimeUpButton_Click(object sender, RoutedEventArgs e)
        {
            watchTime.Text = DateTime.Parse(watchTime.Text).AddMinutes(1).ToShortTimeString();
        }

        private void TimeDownButton_Click(object sender, RoutedEventArgs e)
        {
            watchTime.Text = DateTime.Parse(watchTime.Text).AddMinutes(-1).ToShortTimeString();
        }

       
        private void ShowPositions()
        {
            lbPositions.ItemsSource = Watch.PosList;
        }

        private void MeasureButton_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan deviation = DateTime.Parse(watchTime.Text) - DateTime.Now;

            string format = (deviation < TimeSpan.Zero ? "\\-" : "\\+") +"mm\\:ss\\.ff";

            tbDeviation.Text = deviation.ToString(format);

        }

        private void AddWatchButton_Click(object sender, RoutedEventArgs e)
        {
            AddWatch addWatchWindow = new();
            addWatchWindow.Show();
        }

        


    }
}