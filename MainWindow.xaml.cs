using System;
using System.Windows;
using System.Windows.Threading;
using static Watch_Precision.Watch;
using static Watch_Precision.Database;
using System.Text.RegularExpressions;

namespace Watch_Precision
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ADD WATCH

        string brand = "";
        string model = "";
        DateTime dt = DateTime.Now;
        TimeSpan dev;
        string position = "";




        public MainWindow()
        {
            InitializeComponent();
            Database dbObject = new Database();
            Watch watch_none = new();

            ShowPositions();
            cbWatches.ItemsSource = watch_none.ReadWatchesNames();
            // Shows all measurements, but default should be last watch? Or maybe create ComboBox allowing choosing which watch stats wanna see (before selecting nothing will be seen).
            PrevMeasurementsLV.ItemsSource = watch_none.ReadMeasurements();

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

            if (cbWatches != null && lbPositions != null)
            {
                Watch watch = new(brand, model, dt, deviation, position);
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
        }

        private void lbPositions_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            position = lbPositions.SelectedItem.ToString();
        }
    }
}