using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceServer.DTO
{
    public class AdminDTO
    {
        [Required]
        [DefaultValue("Logging-Admin")]
        public string Username { get; set; }

        [Required]
        [DefaultValue("Testpassword1!")]
        public string Password { get; set; }

        [DefaultValue("bac9986d-c95f-4f6c-a0c2-16801f4d08a4")] //Log admin
        public Guid AccountTypeId { get; set; }

        [DefaultValue("bd22cb11-ff86-4295-ac73-a9c79516087b")]
        public Guid NodeId { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}
