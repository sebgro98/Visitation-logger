using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationServer.Model
{
    [Table("admins")]
    public class Admin
    {
       public enum AdminTypeEnum
        {
            MasterAdmin,
            LoggAdmin
        }

        [Column("id")]
        public Guid Id { get; set; }

        [Column("fullname")]
        [Required]
        public string FullName { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("admin_type")]
        public AdminTypeEnum AdminType { get; set; }
    }
}
