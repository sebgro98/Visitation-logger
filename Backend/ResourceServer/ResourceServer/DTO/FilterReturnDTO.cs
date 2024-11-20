using SharedModels.Models;

namespace ResourceServer.DTO
{
    public class FilterReturnDTO
    {
        public List<Status> StatusList { get; set; }
        public int TotalNumberOfElements { get; set; }
    }
}
