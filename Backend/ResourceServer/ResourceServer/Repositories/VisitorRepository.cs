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

        public async Task<Visitor> UpdateVisitor(Guid id, VisitorDTOPut visitorPutDTO)
        {
            var visitorToUpdate = await _context.Visitors.FindAsync(id);
            var foundCountry = await GetCountry(visitorPutDTO.CountryName);

            if (visitorToUpdate == null)
            {
                return null;
            }

            visitorToUpdate.FullName = visitorPutDTO.FullName;
            visitorToUpdate.SSN = visitorPutDTO.SSN;
            visitorToUpdate.City = visitorPutDTO.City;    
            visitorToUpdate.Country = foundCountry;
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

        public async Task<Visitor> CreateVisitor(VisitorDTOPost dto)
        {
            var foundCountry = await GetCountry(dto.CountryName);

            if (foundCountry == default)
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

        //Find country by name. Can be replaced with AutoMapper
        public async Task<Country> GetCountry(string countryName)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.CountryName == countryName);

            if(country == null)
            {
                return null;
            }

            return country;
        }
    }
}