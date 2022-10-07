using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_Precision.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public TimeSpan Deviation { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Position { get; set; } = null!;
        public int WatchId { get; set; }

        public Watch Watch { get; set; } = null!;
    }
}
