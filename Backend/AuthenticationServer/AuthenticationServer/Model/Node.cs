using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationServer.Model
{
    [Table("nodes")]
    public class Node
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("node_name")]
        public string NodeName { get; set; }

    }

}
