using System;
using System.ComponentModel.DataAnnotations.Schema;

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
