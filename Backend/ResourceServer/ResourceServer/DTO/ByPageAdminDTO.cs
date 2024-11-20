using SharedModels.Models;

namespace ResourceServer.DTO
{
    public class ByPageAdminDTO
    {
        public List<Admin> Admins { get; set; }
        public int totalAmountOfItems { get; set; }
        public int totalPages { get; set; }
    }
}