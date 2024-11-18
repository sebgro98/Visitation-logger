using SharedModels.Models;
using ResourceServer.DTO;

namespace ResourceServer.Repositories
{
    public interface IVisitorRepository
    {
        Task<IEnumerable<Visitor>> GetAllVisitors();
        Task<Visitor> GetVisitorById(Guid id);
        Task<Visitor> UpdateVisitor(Guid id, VisitorDTOPut dto);
        Task<Visitor> CreateVisitor(VisitorDTOPost dto);
        Task DeleteVisitor(int id);
    }
}