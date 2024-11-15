using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ResourceServer.DTO
{
    public class AdminDTO
    {
        [DefaultValue("admin")]
        public string Username { get; set; }

        [DefaultValue("password")]
        public string Password { get; set; }

        [DefaultValue("36a817d3-4445-4779-a60b-23dc36d72cbf")] //Log admin
        public Guid AccountTypeId { get; set; }
    }
}
