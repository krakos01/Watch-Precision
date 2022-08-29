using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Watch_Precision
{

    public class Watch
    {

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


        public int ID { get; set; }
        public string Brand { get; set; }
        public string? Model { get; set; }
        public string DateOfCheck { get; set; }
        public double Deviation  { get; set; }
        public string Position { get; set; } 

    }
}
