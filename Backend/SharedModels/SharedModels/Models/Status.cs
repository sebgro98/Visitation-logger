using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace SharedModels.Models
{
    [Table("status")]
    public class Status
    {
        [Column("id")]
        public Guid Id { get; set; }

        // Foreign key for Visitor
        [JsonIgnore]
        [Column("visitor_id")]
        public Guid VisitorId { get; set; }

        // Navigation property for Visitor
        public virtual Visitor Visitor { get; set; }

        [Column("check_in_time")]
        public DateTime CheckInTime { get; set; }

        [Column("check_in_sign")]
        public string CheckInSign { get; set; }

        [Column("check_out_time")]
        public DateTime? CheckOutTime { get; set; }

        [Column("check_out_sign")]
        public string CheckOutSign { get; set; }

        [Column("last_export_date")]
        public DateTime? LastExportDate { get; set; }

        // Foreign key for Node
        [Column("node_id")]
        public Guid NodeId { get; set; }

        // Navigation property for Node
        public virtual Node Node { get; set; }
    }
}
