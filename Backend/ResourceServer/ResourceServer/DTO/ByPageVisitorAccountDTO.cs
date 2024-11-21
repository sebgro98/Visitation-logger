using SharedModels.Models;

namespace ResourceServer.DTO
{
    public class ByPageVisitorAccountDTO
    {
        public List<VisitorAccount> Data { get; set; }
        public int totalAmountOfItems { get; set; }
        public int totalPages { get; set; }
    }
}