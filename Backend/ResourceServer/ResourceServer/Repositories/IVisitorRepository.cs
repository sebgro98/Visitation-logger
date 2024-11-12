using ResourceServer.Model;

namespace ResourceServer.Repositories
{
    public interface IVisitorRepository
    {
        Task<IEnumerable<Visitor>> GetAllVisitors();
        Task<Visitor> GetVisitorById(int id);
        Task<Visitor> UpdateVisitor(int id, Visitor visitor);
        Task<Visitor> CreateVisitor(Visitor visitor);
        Task DeleteVisitor(int id);
    }
}