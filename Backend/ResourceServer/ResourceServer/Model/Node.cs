using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceData.Model
{
    [Table("nodes")]
    public class Node
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("node_name")]
        [Required]
        public string NodeName { get; set; }

    }

}
