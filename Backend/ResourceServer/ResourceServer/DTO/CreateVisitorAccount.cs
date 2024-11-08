using AuthenticationServer.Model;
using System.ComponentModel.DataAnnotations;

namespace ResourceServer.DTO
{
    public class VisitorAccountDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string UserName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid PurposeTypeId { get; set; }

        public string PurposeTypeName { get; set; }

        public PurposeTypeEnum PurposeTypeEnum { get; set; }

        public Guid VisitorId { get; set; }
    }

}