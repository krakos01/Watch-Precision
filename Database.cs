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
        public string Dev { get; set; }
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

    }
}
