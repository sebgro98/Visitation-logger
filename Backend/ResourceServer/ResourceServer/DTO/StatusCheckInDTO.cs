using System.ComponentModel.DataAnnotations;

namespace ResourceServer.DTO
{
    public class StatusCheckInDTO
    {
        [Required]
        public Guid VisitorAccountId { get; set; }

        [Required]
        public DateTime CheckInTime { get; set; }

        [Required]
        public string CheckInSign { get; set; }

        [Required]
        public Guid NodeId { get; set; }
    }
}
