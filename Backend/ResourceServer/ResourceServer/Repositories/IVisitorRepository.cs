using ResourceServer.Model;
using ResourceServer.DTO;

namespace ResourceServer.Repositories
{
    public interface IVisitorRepository
    {
        Task<IEnumerable<Visitor>> GetAllVisitors();
        Task<Visitor> GetVisitorById(int id);
        Task<Visitor> UpdateVisitor(int id, Visitor visitor);
        Task<Visitor> CreateVisitor(VisitorDTO dto);
        Task DeleteVisitor(int id);
    }
}