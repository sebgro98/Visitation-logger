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

        // Navigation property
        [ForeignKey("AccountTypeId")]
        public virtual AccountType AccountType { get; set; }
    }
}
