using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationServer.Model
{
    [Table("Country")]
    public class Country
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("country_name")]
        [Required]
        public string CountryName { get; set; }
    }
}
