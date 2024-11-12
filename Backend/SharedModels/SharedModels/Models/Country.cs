using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SharedModels.Models
{
    [Table("Countries")]
    public class Country
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("country_name")]
        [Required]
        public string CountryName { get; set; }
    }
}
