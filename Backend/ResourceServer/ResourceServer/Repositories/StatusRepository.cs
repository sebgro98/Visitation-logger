using ResourceServer.Data;
using ResourceServer.DTO;
using SharedModels.Models;
using Microsoft.EntityFrameworkCore;

namespace ResourceServer.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public StatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Status>> GetAllStatuses()
        {
            return await _context.Status.ToListAsync();
        }

        public async Task<Status> GetStatusById(Guid id)
        {
            return await _context.Status.FindAsync(id);
        }

        public async Task<Status> UpdateStatus(Guid id, StatusCheckOutDTO statusDTO)
        {
            var statusToUpdate = await _context.Status.FindAsync(id);

            if (statusToUpdate == null)
            {
                return null;
            }

            if (statusDTO.IsExport)
            {
                statusToUpdate.LastExportDate = statusDTO.LastExportDate;

                _context.Status.Update(statusToUpdate);
                await _context.SaveChangesAsync();

                return statusToUpdate;
            }

            statusToUpdate.CheckOutTime = statusDTO.CheckOutTime;
            statusToUpdate.CheckOutSign = statusDTO.CheckOutSign;
          
            _context.Status.Update(statusToUpdate);
            await _context.SaveChangesAsync();

            return statusToUpdate;
        }

        public async Task DeleteStatus(Guid id)
        {
            var status = await _context.Status.FindAsync(id);
            if (status != null)
            {
                _context.Status.Remove(status);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Status> CreateStatus(StatusCheckInDTO statusCheckInDto)
        {

            var newStatus = new Status
            {
                Id = Guid.NewGuid(),
                VisitorId = statusCheckInDto.VisitorId,
                CheckInSign = statusCheckInDto.CheckInSign,
                CheckInTime = statusCheckInDto.CheckInTime,
                NodeId = statusCheckInDto.NodeId,
            };

            _context.Status.Add(newStatus);
            await _context.SaveChangesAsync();
            return newStatus;
        }

        public async Task<Status> GetCheckInStatus(Guid visitorId)
        {
            var latestStatus = await _context.Status
            .Where(s => s.VisitorId == visitorId)
            .OrderByDescending(s => s.CheckInTime)
            .FirstOrDefaultAsync();

            return latestStatus;
        }
    }
}