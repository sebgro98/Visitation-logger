using System.ComponentModel.DataAnnotations;

namespace ResourceServer.DTO
{
    public class VisitorDTOPost : IVisitorDTO
    {
        [Required]
        public string FullName { get; set; }
        
        [Required]
        public string SSN { get; set; }

        [Required]
        public string CountryName { get; set; }

        [Required]
        public string PassportNo { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public Guid VisitorAccountId { get; set; }
    }
}
