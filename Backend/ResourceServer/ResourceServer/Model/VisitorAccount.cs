using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceServer.Model
{
    [Table("visitorAccounts")]
    public class VisitorAccount
    {
        // Foreign Key to PurposeType
        [Column("purpose_type_id")]
        public Guid PurposeTypeId { get; set; }

        // Navigation property to PurposeType
        [ForeignKey("PurposeTypeId")]
        public PurposeType PurposeType { get; set; }

        [Column("id")]
        public Guid Id { get; set; }

        [StringLength(100, MinimumLength = 4)]
        [Required]
        [Column("username")]
        public string UserName { get; set; }

        [StringLength(100, MinimumLength = 8)]
        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        public Guid? VisitorId { get; set; }

        public Visitor Visitor { get; set; }


        /*[NotMapped]
        public PurposeTypeEnum PurposeTypeEnum
        {
            get
            {
                return PurposeType.Name switch
                {
                    "Service" => PurposeTypeEnum.Service,
                    "Event" => PurposeTypeEnum.Event,
                    "Meeting" => PurposeTypeEnum.Meeting,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            set
            {
                PurposeType.Name = value.ToString();
            }
        }*/
    }
}
