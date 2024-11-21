using SharedModels.Models;

namespace ResourceServer.DTO
{
    public class FilterReturnDTO
    {
        public List<StatusDTO> StatusList { get; set; }
        public int TotalNumberOfElements { get; set; }
        public int TotalNumberOfPages { get; set; }
    }
}
