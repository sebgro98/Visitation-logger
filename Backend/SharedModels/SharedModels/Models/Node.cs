using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SharedModels.Models
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
