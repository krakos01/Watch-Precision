using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.SQLite;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Windows.Threading;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watch_Precision.Models
{

    public class Watch
    {
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = null!;
        public string? AdditionalInformaction { get; set; }

        public ICollection<Measurement> Measurements { get; set; } = null!;




        /*  Before EF (db creation, list of postions, CRUD operations)
         
         
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
            string query = "SELECT Brand FROM Watches";
            SQLiteCommand myCommand = new(query, dbObject.myConnection);
            dbObject.OpenConnection();
            SQLiteDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string temp = reader[0].ToString();
                    results.Add(temp);
                }
            }
            dbObject.CloseConnection();

            return results;
        }

        public List<Data> ReadMeasurements(string brand)
        {
            List<Data> results = new();

            string query = string.Format("SELECT * FROM Watch_times WHERE WatchID IN (SELECT ID FROM Watches WHERE Brand = '{0}') ORDER BY Date DESC", brand);
            SQLiteCommand myCommand = new(query, dbObject.myConnection);

            dbObject.OpenConnection();
            SQLiteDataReader reader = myCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new Data() { Date = (string)reader[1], Deviation = (string)reader[2], Position = (string)reader[3] });
                }
            }
            dbObject.CloseConnection();

            return results;
        }

        public void InsertWatch(string name)
        {
            string query = string.Format("INSERT INTO Watches ('Brand') VALUES ('{0}')", name);
            SQLiteCommand myCommand = new(query, dbObject.myConnection);

            dbObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            dbObject.CloseConnection();
        }

        public void DeleteWatch(string name)
        {
            string query = string.Format("DELETE FROM Watches WHERE Brand='{0}'", name);
            SQLiteCommand myCommand = new(query, dbObject.myConnection);

            dbObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            dbObject.CloseConnection();
        }

        public void InsertMeasurement()
        {
            string query = string.Format("INSERT INTO Watch_times VALUES ((SELECT ID FROM Watches WHERE Brand = '{0}'), datetime('now'), '{1}', '{2}')", Brand, Deviation, Position);
            SQLiteCommand myCommand = new(query, dbObject.myConnection);

            dbObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            dbObject.CloseConnection();

        }

        public void DeleteMeasurement(string date)
        {
            string query = string.Format("DELETE FROM Watch_times WHERE Date='{0}'", date);
            SQLiteCommand myCommand = new(query, dbObject.myConnection);

            dbObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            dbObject.CloseConnection();
        }

        */
    }
}
