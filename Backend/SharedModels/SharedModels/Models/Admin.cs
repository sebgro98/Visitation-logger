using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SharedModels.Models
{
    [Table("admins")]
    public class Admin
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
        public int FailedLoginAttempts { get; set; } = 0;

        [Column("lockout_end")]
        public DateTime? LockoutEnd { get; set; }
    }
}
