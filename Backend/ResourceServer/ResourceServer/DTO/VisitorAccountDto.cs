using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AuthenticationServer.Model;

namespace AuthenticationServer.DTO
{
    public class VisitorAccountDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string UserName { get; set; }

        [StringLength(100, MinimumLength = 8)]
        [Required]
        public string Password { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid PurposeTypeId { get; set; }

        public Guid VisitorId { get; set; }
    }
}