using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using static Watch_Precision.Database;

namespace Watch_Precision
{

    public class Watch
    {
        Database dbObject = new Database();

        public static List<string> PosList = new()
        {
            "Worn",
            "On the winder",
            "Dial up (horizontal)",
            "Dial down (horizontal)",
            "12 up (vertical)",
            "3 up (vertical)",
            "6 up (vertical)",
            "9 up (vertical)",
            "Unspecified"
        };

        public Watch() { }

        public Watch(string brand, string deviation, string position)
        {
            Brand = brand;
            Deviation = deviation;
            Position = position;
        }

        public string Brand { get; set; }
        public string Deviation { get; set; }
        public string Position { get; set; }



        public List<string> ReadWatchesNames()
        {
            List<string> results = new();
            string query = "SELECT Brand, Model FROM Watches";
            SQLiteCommand myCommand = new(query, dbObject.myConnection);
            dbObject.OpenConnection();
            SQLiteDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string temp = reader[0].ToString() + " " + reader[1].ToString();
                    results.Add(temp);
                }
            }
            dbObject.CloseConnection();

            return results;
        }

        public List<Data> ReadMeasurements()
        {

            List<Data> results = new();

            string query = "SELECT * FROM Watch_times";
            SQLiteCommand myCommand = new(query, dbObject.myConnection);
            dbObject.OpenConnection();
            SQLiteDataReader reader = myCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new Data() { Dat = (string)reader[1], Dev = (string)reader[2], Pos = (string)reader[3] });
                }
            }
            dbObject.CloseConnection();


            return results;
        }

        public List<Data> ReadMeasurements(string brand)
        {

            List<Data> results = new();

            string query = String.Format("SELECT * FROM Watch_times WHERE WatchID IN (SELECT ID FROM Watches WHERE Brand = '{0}') ORDER BY Date DESC", brand);
            SQLiteCommand myCommand = new(query, dbObject.myConnection);
            dbObject.OpenConnection();
            SQLiteDataReader reader = myCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new Data() { Dat = (string)reader[1], Dev = (string)reader[2], Pos = (string)reader[3] });
                }
            }
            dbObject.CloseConnection();


            return results;
        }

        public void InsertWatch(string name)
        {
            string query = String.Format("INSERT INTO Watches ('Brand', 'Model') VALUES ('{0}', '')", name);
            SQLiteCommand myCommand = new(query, dbObject.myConnection);
            dbObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            dbObject.CloseConnection();
        }

        public void DeleteWatch(string name)
        {
            string query = String.Format("DELETE FROM Watches WHERE Brand='{0}'", name);
            SQLiteCommand myCommand = new(query, dbObject.myConnection);
            dbObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            dbObject.CloseConnection();
        }

        public void InsertMeasurement()
        {            
            string query = String.Format("INSERT INTO Watch_times VALUES ((SELECT ID FROM Watches WHERE Brand = '{0}'), datetime('now'), '{1}', '{2}')", Brand, Deviation, Position);
            SQLiteCommand command = new(query, dbObject.myConnection);

            dbObject.OpenConnection();
            command.ExecuteNonQuery();
            dbObject.CloseConnection();
            
        }
    }
}
