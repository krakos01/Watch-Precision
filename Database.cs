using System.IO;
using System.Data.SQLite;
using System.Reflection.Metadata;
using static Watch_Precision.MainWindow;
using System.Windows.Documents;
using System.Windows.Resources;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace Watch_Precision
{
    public struct Data
    {
        public string Dat { get; set; }
        public double Dev { get; set; }
        public string Pos { get; set; }
    }

    public class Database
    {
        public SQLiteConnection myConnection;

        public Database()
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");

            if (!File.Exists("./database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3");
            }

                
        }

        public void OpenConnection()
        {
            if (myConnection.State == System.Data.ConnectionState.Closed) myConnection.Open();
        }

        public void CloseConnection()
        {
            if (myConnection.State == System.Data.ConnectionState.Open) myConnection.Close();
        }
        


        public List<string> ReadWatchesNames()
        {
            List<string> results = new();
            string query = "SELECT Brand, Model FROM Watches";
            SQLiteCommand myCommand = new(query, myConnection);
            OpenConnection();
            SQLiteDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string temp = reader[0].ToString() + " " + reader[1].ToString();
                    results.Add(temp);
                }
            }
            CloseConnection();

            return results;
        }


        public List<Data> ReadMeasurements()
        {
            
             List<Data> data = new();

             string query = "SELECT * FROM Watch_times";
             SQLiteCommand myCommand = new(query, myConnection);
             OpenConnection();
             SQLiteDataReader reader = myCommand.ExecuteReader();

             if (reader.HasRows)
             {
                 while (reader.Read())
                 {
                     data.Add(new Data() { Dat = (string)reader[1], Dev = (double)reader[2], Pos = (string)reader[3] });
                 }
             }

             CloseConnection();
            
            return data;
        }

    }
}
