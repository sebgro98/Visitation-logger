using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceServer.Model
{
    [Table("visitors")]
    public class Visitor
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("fullname")]
        [Required]
        public string FullName { get; set; }

        [Column("SSN")]
        [Required]
        public string SSN { get; set; }

        // One-to-Many relationship with Status (adjust based on actual relationship)

        public ICollection<Status> Status { get; set; }

        // Foreign Key for Country
        [Column("country_id")]
        public Guid CountryId { get; set; }

        // Navigation property for Country
        public Country Country { get; set; }

        [Required]
        [Column("passport_no")]
        public string PassportNo { get; set; }

        [Required]
        [Column("company")]
        public string Company { get; set; }

        [Required]
        [Column("city")]
        public string City { get; set; }

        public ICollection<VisitorAccount> VisitorAccounts { get; set; }
    }
}