using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ResourceServer.DTO
{
    public interface IVisitorAccountDTO
    {     
        public string Username { get; set; }
        
        public string Password { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    
        public Guid PurposeTypeId { get; set; }
 
        public Guid? VisitorId { get; set; }
        public Guid AccountTypeId { get; set; }

        public Guid NodeId { get; set; }
    }
}

