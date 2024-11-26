using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SharedModels.Interface;

namespace SharedModels.Models
{
    [Table("visitorAccounts")]
    public class VisitorAccount : IAccountLockout
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
        [JsonIgnore]
        public string Password { get; set; }

        [Column("start_date")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        [Required]
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        [Column("visitor_id")]
        public Guid? VisitorId { get; set; }

        public virtual Visitor Visitor { get; set; }

        [Column("account_type_id")]
        [JsonIgnore]
        public Guid AccountTypeId { get; set; }

        public virtual AccountType AccountType { get; set; }
       
        [Column("purpose_type_id")]
        [JsonIgnore]
        public Guid PurposeTypeId { get; set; }

        public virtual PurposeType PurposeType { get; set; }

        [Column("node_id")]
        public Guid NodeId { get; set; }

        public virtual Node Node { get; set; }

        [Column("failed_login_attempts")]
        [JsonIgnore]
        public int FailedLoginAttempts { get; set; } = 0;

        [Column("lockout_end")]
        [JsonIgnore]
        public DateTime? LockoutEnd { get; set; }
    }
}
