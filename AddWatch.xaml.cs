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
using Watch_Precision.Models;
using Watch_Precision.Data;

namespace Watch_Precision
{
    /// <summary>
    /// Logika interakcji dla klasy AddWatch.xaml
    /// </summary>


    public partial class AddWatch : Window
    {
        List<Watch> watches = new();

        public AddWatch()
        {
            InitializeComponent();

            LoadWatchesList();
        }

        private void LoadWatchesList()
        {
            watches = SqliteDataAccess.LoadWatches();

            WatchesLV.ItemsSource = null;
            WatchesLV.ItemsSource = watches.Select(x => x.Name).ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Watch watch = new();
            watch.Name = WatchTB.Text;

            // Adds with space, so must check with added space
            if (!WatchesLV.Items.Contains(watch.Name+' '))
            {
                SqliteDataAccess.SaveWatch(watch);
                LoadWatchesList();
            }
            else MessageBox.Show("Names cannot be repeated");
        }

        /*
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (WatchesLV.SelectedItem != null)
            {

                // Adds with space, so must trim
                watchName = WatchesLV.SelectedItem.ToString().Trim();
                WatchTB.Text = watchName.Length.ToString();

                watch_none.DeleteWatch(watchName);
                WatchesLV.ItemsSource = watch_none.ReadWatchesNames();
            }
        }
        */

    }
        
}
