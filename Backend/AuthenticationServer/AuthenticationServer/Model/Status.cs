using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationServer.Model
{
    [Table("status")]
    public class Status
    {
        [Column("id")]
        public Guid Id { get; set; }

        // Foreign key for Visitor
        public Guid VisitorId { get; set; }

        // Navigation property for Visitor
        public Visitor Visitor { get; set; }

        [Column("check_in_time")]
        public DateTime CheckInTime { get; set; }

        [Column("check_in_sign")]
        public string CheckInSign { get; set; } 

        [Column("check_out_time")]
        public DateTime CheckOutTime { get; set; }

        [Column("check_out_sign")]
        public string CheckOutSign { get; set; }

        [Column("last_export_date")]
        public DateTime LastExportDate { get; set; }

        // Foreign key for Node
        public Guid NodeId { get; set; }

        // Navigation property for Node
        public Node Node { get; set; }
    }
}