using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ResourceServer.DTO
{
    public class VisitorAccountPutDTO : IVisitorAccountDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 4)]
        [DefaultValue("jane.smith")]
        public string Username { get; set; }

        public string? Password { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [DefaultValue("edb56ab7-8a8c-4ba3-af01-8671a8648833")] 
        public Guid PurposeTypeId { get; set; }

        [DefaultValue("6de88bd3-40a5-4153-bbd8-83e54a51d7f6")]
        public Guid? VisitorId { get; set; }

        [DefaultValue("a2f5ef84-10f0-4e05-a3a3-fcbe73728d16")]
        public Guid AccountTypeId { get; set; }

        [DefaultValue("bd22cb11-ff86-4295-ac73-a9c79516087b")]
        public Guid NodeId { get; set; }
    }
}
