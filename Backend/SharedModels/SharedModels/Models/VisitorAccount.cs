using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace SharedModels.Models
{
    [Table("visitorAccounts")]
    public class VisitorAccount
    {
        
        [Column("id")]
        public Guid Id { get; set; }

        [StringLength(50, MinimumLength = 4)]
        [Required]
        [Column("username")]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 8)]
        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("start_date")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        [Required]
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public Guid? VisitorId { get; set; }

        public virtual Visitor Visitor { get; set; }

        [Column("account_type_id")]
        [JsonIgnore]
        public Guid AccountTypeId { get; set; }

        [ForeignKey("AccountTypeId")]
        public virtual AccountType AccountType { get; set; }

        // Foreign Key to PurposeType
        [Column("purpose_type_id")]
        [JsonIgnore]
        public Guid PurposeTypeId { get; set; }

        // Navigation property to PurposeType
        [ForeignKey("PurposeTypeId")]
        public virtual PurposeType PurposeType { get; set; }

        [Column("node_id")]
        public Guid NodeId { get; set; }

        public Node Node { get; set; }
    }
}
