using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationServer.Model
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

        
        [NotMapped]  // This will not be stored in the database
        public AdminTypeEnum AdminTypeEnum
        {
            get
            {
                return AdminType.Name switch
                {
                    "MasterAdmin" => AdminTypeEnum.MasterAdmin,
                    "LoggAdmin" => AdminTypeEnum.LoggAdmin,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            set
            {
                AdminType.Name = value.ToString();
            }
        }
    }
}
