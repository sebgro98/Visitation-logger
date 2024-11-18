using SharedModels.Models;

namespace ResourceServer.Repositories
{
    public interface INodeRepository 
    {
        Task<IEnumerable<Node>> GetAllNodes();
    }
}