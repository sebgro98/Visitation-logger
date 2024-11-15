using System.ComponentModel.DataAnnotations;

namespace ResourceServer.DTO
{
    public class StatusCheckOutDTO
    {
        [Required]
        public DateTime CheckOutTime { get; set; }

        [Required]
        public string CheckOutSign { get; set; }

        public DateTime LastExportDate { get; set; }

        [Required]
        public bool IsExport { get; set; }

    }
}
