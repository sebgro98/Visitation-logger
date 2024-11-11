using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceServer.Model
{
    [Table("admins")]
    public class Admin
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("fullname")]
        [Required]
        public string FullName { get; set; }

        [StringLength(100, MinimumLength = 8)]
        [Required]
        [Column("password")]
        public string Password { get; set; }

        
        [Column("admin_type_id")]
        public Guid AdminTypeId { get; set; }

        // Navigation property
        [ForeignKey("AdminTypeId")]
        public AdminType AdminType { get; set; }
    }
}
