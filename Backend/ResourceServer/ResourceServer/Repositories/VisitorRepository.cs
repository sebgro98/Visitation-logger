using ResourceServer.Data;
using ResourceServer.DTO;
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

        public async Task<Visitor> GetVisitorById(Guid id)
        {
            return await _context.Visitors.FindAsync(id);
        }

        public async Task<Visitor> UpdateVisitor(Guid id, VisitorPutDTO visitorPutDTO)
        {
            var visitorToUpdate = await _context.Visitors.FindAsync(id);

            if (visitorToUpdate == null)
            {
                return null;
            }

            visitorToUpdate.FullName = visitorPutDTO.FullName;
            visitorToUpdate.SSN = visitorPutDTO.SSN;
            visitorToUpdate.City = visitorPutDTO.City;    
            visitorToUpdate.CountryId = visitorPutDTO.CountryId;
            visitorToUpdate.PassportNo = visitorPutDTO.PassportNo;
            visitorToUpdate.Company = visitorPutDTO.Company;
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

        public async Task<Visitor> CreateVisitor(VisitorDTO dto)
        {
            //Find country by name. Can be replaced with AutoMapper
            var foundCountry = await _context.Countries.FirstOrDefaultAsync(c => c.CountryName == dto.CountryName);

            if (foundCountry == null)
            {
                return null;
            }

            var newVisitor = new Visitor
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName,
                SSN = dto.SSN,
                Country = foundCountry,
                PassportNo = dto.PassportNo,
                Company = dto.Company,
                City = dto.City,
            };

            _context.Visitors.Add(newVisitor);
            await _context.SaveChangesAsync();
            return newVisitor;
        }
    }
}