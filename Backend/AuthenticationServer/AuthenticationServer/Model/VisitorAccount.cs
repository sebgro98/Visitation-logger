using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationServer.Model
{

    [Table("visitorAccounts")]
    public class VisitorAccount
    {
       public enum PurposeTypeEnum
        {
            Service,
            Event,
            Meeting
        }

        [Column("id")]
        public Guid Id { get; set; }

        [Column("username")]
        public string UserName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate  { get; set; }

        [Column("purpose_type")]
        public PurposeTypeEnum PurposeType { get; set; }

        [ForeignKey("visitor")]
        public Guid VisitorId { get; set; }

        public Visitor Visitor { get; set; }
    }
}
