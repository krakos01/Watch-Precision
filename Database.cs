using System.IO;
using System.Data.SQLite;
using System.Reflection.Metadata;
using static Watch_Precision.MainWindow;
using System.Windows.Documents;
using System.Windows.Resources;
using System.Collections.Generic;

namespace Watch_Precision
{
    public class Database
    {
        public SQLiteConnection myConnection;

        public Database()
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");

            if (!File.Exists("./database.sqlite3"))  SQLiteConnection.CreateFile("database.sqlite3");
        }

        public void OpenConnection()
        {
            if (myConnection.State == System.Data.ConnectionState.Closed) myConnection.Open();
        }

        public void CloseConnection()
        {
            if (myConnection.State == System.Data.ConnectionState.Open) myConnection.Close();
        }
        

        public List<string> ShowAllWatches()
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

    }
}
