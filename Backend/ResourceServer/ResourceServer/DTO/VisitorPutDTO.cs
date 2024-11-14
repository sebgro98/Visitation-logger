using System.ComponentModel.DataAnnotations;

namespace ResourceServer.DTO
{
    public class VisitorPutDTO
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string SSN { get; set; }

        [Required]
        public Guid CountryId { get; set; }

        [Required]
        public string PassportNo { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string City { get; set; }
    }
}
