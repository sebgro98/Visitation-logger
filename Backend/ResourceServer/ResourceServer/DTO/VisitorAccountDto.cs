using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ResourceServer.DTO
{
    public class VisitorAccountDto
    {
        [Required]
        [StringLength(100, MinimumLength = 4)]
        [DefaultValue("jane.smith")]
        public string UserName { get; set; }

        [StringLength(100, MinimumLength = 8)]
        [Required]
        [DefaultValue("Testpassword1!")]
        public string Password { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [DefaultValue("edb56ab7-8a8c-4ba3-af01-8671a8648833")] //Service
        public Guid PurposeTypeId { get; set; }

        [DefaultValue("6de88bd3-40a5-4153-bbd8-83e54a51d7f6")] //Jane Smith
        public Guid? VisitorId { get; set; }

        [DefaultValue("a2f5ef84-10f0-4e05-a3a3-fcbe73728d16")] //Visitor account
        public Guid AccountTypeId { get; set; }

        [DefaultValue("bd22cb11-ff86-4295-ac73-a9c79516087b")]
        public Guid NodeId { get; set; }
    }
}
