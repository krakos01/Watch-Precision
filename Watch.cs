using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Watch(string brand, string model, DateTime dateOfCheck, TimeSpan deviation, string position)
        {
            Brand = brand;
            Model = model;
            DateOfCheck = dateOfCheck;
            Deviation = deviation;
            Position = position;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime DateOfCheck { get; set; }
        public TimeSpan Deviation { get; set; }
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
                    results.Add(new Data() { Dat = (string)reader[1], Dev = (double)reader[2], Pos = (string)reader[3] });
                }
            }
            dbObject.CloseConnection();


            return results;
        }

    }
}
