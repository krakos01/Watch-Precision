using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Windows;
using Watch_Precision.Models;

namespace Watch_Precision.Data
{
    public class SqliteDataAccess
    {
        public static List<Watch> LoadWatches()
        {
            var sql = "SELECT * FROM Watches";
            var myWatches = new List<Watch>();

            using (var cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Open();
                myWatches = (List<Watch>)cnn.Query<Watch>(sql);

                MessageBox.Show(myWatches[0].Name.ToString());

                return myWatches;
            }
        }

        public static void SaveWatch(Watch watch)
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Watches (Brand) values (@Brand)", watch.Name);
            }
        }



        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
