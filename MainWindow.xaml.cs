using System;
using System.Windows;
using System.Windows.Threading;
using static Watch_Precision.Watch;
using static Watch_Precision.Database;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Data;
using System.Linq;

namespace Watch_Precision
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string brand;
        string position;
        readonly Watch _ = new();

        public MainWindow()
        {
            InitializeComponent();
            Database dbObject = new Database();

            ShowPositions();
            cbWatches.ItemsSource = _.ReadWatchesNames();

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
            
            if (cbWatches.SelectedItem != null && lbPositions.SelectedItem != null)
            {
               Watch nw = new(brand, deviation.ToString(), position);
                nw.InsertMeasurement();
                PrevMeasurementsDG.ItemsSource = _.ReadMeasurements(brand);
                MessageBox.Show(deviation.ToString());

                GetAvg();
            }
        }

        private void AddWatchButton_Click(object sender, RoutedEventArgs e)
        {
            AddWatch addWatchWindow = new();
            addWatchWindow.Show();
        }

        private void cbWatches_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            brand = cbWatches.SelectedItem.ToString();
            brand = brand.Substring(0, brand.IndexOf(' '));
            PrevMeasurementsDG.ItemsSource = _.ReadMeasurements(brand);

            GetAvg();
        }

        private void lbPositions_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            position = lbPositions.SelectedItem.ToString();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var item = PrevMeasurementsDG.SelectedItem;

            if (item != null)
            {
                string date = (item as Data).Date.ToString();
                string dev = (item as Data).Deviation.ToString();
                _.DeleteMeasurement(date, dev);

                PrevMeasurementsDG.ItemsSource = _.ReadMeasurements(brand);
                GetAvg();
            }
        }

        private void GetAvg()
        {
            var item = _.ReadMeasurements();
        
            var deviationsList = item
                .Select(x => x.Deviation)
                .ToList();

            var average = deviationsList
                .Select(TimeSpan.Parse)
                .Average(x => x.TotalMilliseconds);

            var avgTime = TimeSpan.FromMilliseconds(average);

            if (avgTime > TimeSpan.FromMilliseconds(0)) {
                tbDeviation.Text = avgTime.ToString(@"mm\:ss\.ff"); }
            else tbDeviation.Text = '-'+avgTime.ToString(@"mm\:ss\.ff");
        }
    }
}