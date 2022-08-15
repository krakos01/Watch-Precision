using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Watch_Precision
{

    internal class Watch
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

        string Model { get; set; }
        enum Position
        {
            Worn,
            Winder,
            DialUp,
            DialDown,
            Up12,
            Up3,
            Up6,
            Up9,
            Unspecified
        }

    }
}
