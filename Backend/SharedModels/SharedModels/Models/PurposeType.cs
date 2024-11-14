using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SharedModels.Models
{
    [Table("purpose_types")]
    public class PurposeType
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }  // "Service", "Event", "Meeting"
    }
}
