using ResourceServer.Data;
using SharedModels.Models;
using Microsoft.EntityFrameworkCore;

namespace ResourceServer.Repositories
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly ApplicationDbContext _context;

        public VisitorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Visitor>> GetAllVisitors()
        {
            return await _context.Visitors.ToListAsync();
        }

        public async Task<Visitor> GetVisitorById(int id)
        {
            return await _context.Visitors.FindAsync(id);
        }



        public async Task<Visitor> UpdateVisitor(int id, Visitor visitor)
        {
            var visitorToUpdate = await _context.Visitors.FindAsync(id);

            if (visitorToUpdate == null)
            {
                return null;
            }
            visitorToUpdate.FullName = visitor.FullName;
            visitorToUpdate.SSN = visitor.SSN;
            visitorToUpdate.City = visitor.City;
            visitorToUpdate.Country = visitor.Country;
            visitorToUpdate.PassportNo = visitor.PassportNo;
            visitorToUpdate.Company = visitor.Company;
            _context.Visitors.Update(visitorToUpdate);
            await _context.SaveChangesAsync();

            return visitorToUpdate;
        }


        public async Task DeleteVisitor(int id)
        {
            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor != null)
            {
                _context.Visitors.Remove(visitor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Visitor> CreateVisitor(Visitor visitor)
        {
            _context.Visitors.Add(visitor);
            await _context.SaveChangesAsync();
            return visitor;
        }
    }
}