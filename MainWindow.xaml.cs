using System;
using System.Windows;
using System.Windows.Threading;
using static Watch_Precision.Models.Watch;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Data;
using System.Linq;
using System.Windows.Input;
using Watch_Precision.Models;
using Watch_Precision.Data;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace Watch_Precision
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Watch _ = new();

        public MainWindow()
        {
            InitializeComponent();
            /*Database dbObject = new Database();

            ShowPositions();
            cbWatches.ItemsSource = _.ReadWatchesNames();

            DispatcherTimer timer = new();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            watchTime.Text = DateTime.Now.ToShortTimeString();
            */
        }

        /*
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

                System.Collections.Generic.List<Data> list = _.ReadMeasurements(brand);
                FormatTimespan(list);
                PrevMeasurementsDG.ItemsSource = list;

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

            if (brand != null)
            {
                System.Collections.Generic.List<Data> list = _.ReadMeasurements(brand);
                FormatTimespan(list);
                PrevMeasurementsDG.ItemsSource = list;

                GetAvg();
            }
        }

        private void lbPositions_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            position = lbPositions.SelectedItem.ToString();
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            var item = PrevMeasurementsDG.SelectedItem;

            if (item != null)
            {
                string date = (item as Data).Date.ToString();
                _.DeleteMeasurement(date);

                System.Collections.Generic.List<Data> list = _.ReadMeasurements(brand);
                FormatTimespan(list);
                PrevMeasurementsDG.ItemsSource = list;
                GetAvg();
            }
        }

        private void GetAvg()
        {
            var item = _.ReadMeasurements(brand);
        
            var deviationsList = item
                .Select(x => x.Deviation)
                .ToList();

            var average = deviationsList
                .Select(TimeSpan.Parse)
                .Average(x => x.TotalMilliseconds);


            // Next lines formats avgTime
            var avgTime = TimeSpan.FromMilliseconds(average);

            if (avgTime > TimeSpan.FromMilliseconds(0)) {
                tbDeviation.Text = avgTime.ToString(@"mm\:ss\.ff"); }
            else tbDeviation.Text = '-'+avgTime.ToString(@"mm\:ss\.ff");
        }

        private void FormatTimespan(System.Collections.Generic.List<Data> list)
        {
            foreach (var item in list)
            {
                TimeSpan timeSpan = TimeSpan.Parse(item.Deviation);
                if (timeSpan > TimeSpan.FromMilliseconds(0))
                {
                    item.Deviation = timeSpan.ToString(@"mm\:ss\.ff");
                }
                else item.Deviation = '-' + timeSpan.ToString(@"mm\:ss\.ff");
            }
        }

        private void DeleteKB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DeleteMI_Click(sender, e);
            }
        }
        */
    }
}