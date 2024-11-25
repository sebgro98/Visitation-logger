using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SharedModels.Interface;

namespace SharedModels.Models
{
    [Table("admins")]
    public class Admin : IAccountLockout
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("username")]
        [StringLength(50, MinimumLength = 4)]
        [Required]
        public string Username { get; set; }

        [StringLength(100, MinimumLength = 8)]
        [Required]
        [Column("password")]
        [JsonIgnore]
        public string Password { get; set; }


        [Column("account_type_id")]
        [JsonIgnore]
        public Guid AccountTypeId { get; set; }

        public virtual AccountType AccountType { get; set; }

        [Column("node_Id")]
        public Guid NodeId { get; set; }
        public virtual Node Node { get; set; }

        public string FullName { get; set; }

        [Column("failed_login_attempts")]
        [JsonIgnore]
        public int FailedLoginAttempts { get; set; } = 0;

        [Column("lockout_end")]
        [JsonIgnore]
        public DateTime? LockoutEnd { get; set; }
    }
}
