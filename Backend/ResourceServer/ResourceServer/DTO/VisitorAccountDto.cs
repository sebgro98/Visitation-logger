using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ResourceServer.DTO
{
    public class VisitorAccountDto
    {
        [Required]
        [StringLength(100, MinimumLength = 4)]
        [DefaultValue("visitor")]
        public string UserName { get; set; }

        [StringLength(100, MinimumLength = 8)]
        [Required]
        [DefaultValue("password")]
        public string Password { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [DefaultValue("a98dc435-e2ce-4470-be62-bf58f677aec7")] //Service
        public Guid PurposeTypeId { get; set; }

        [DefaultValue("a02cecf6-0749-48ba-bccd-f5871df211ab")] //Jane Smith
        public Guid? VisitorId { get; set; }

        [DefaultValue("28633ad3-cce7-4cd5-85dd-5b27d93a60c9")] //Visitor account
        public Guid AccountTypeId { get; set; }
    }
}
