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

        List<string> Positions = new()
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

        string Name { get; set; }
        enum Position
        {
            Worn,
            [Display(Name = "On the winder")]
            Winder,
            [Display(Name = "Dial up (horizontal)")]
            DialUp,
            [Display(Name = "Dial down (horizontal)")]
            DialDown,
            [Display(Name = "12 up (vertical)")]
            Up12,
            [Display(Name = "3 up (vertical)")]
            Up3,
            [Display(Name = "6 up (vertical)")]
            Up6,
            [Display(Name = "9 up (vertical)")]
            Up9,
            Unspecified


        }

    }
}
