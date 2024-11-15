using SharedModels.Models;
using ResourceServer.DTO;
using ResourceServer.Data;
using Microsoft.EntityFrameworkCore;

namespace ResourceServer.Repositories 
{ 
    public class NodeRepository : INodeRepository 
    {
        private readonly ApplicationDbContext _context;

        public NodeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Node>> GetAllNodes()
        {
            return await _context.Nodes.ToListAsync();
        }
    }
}
