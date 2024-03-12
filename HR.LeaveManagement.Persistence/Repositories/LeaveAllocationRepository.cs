using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly HrDatabaseContext _context;

        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
            this._context = context;
        }

        public async Task AddAllocatoin(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync();
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId 
                                        && q.LeaveTypeId == leaveTypeId 
                                        && q.Preiod == period);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leavAllocations = await _context.LeaveAllocations.Include(q => q.LeaveType)
                .ToListAsync();

            return leavAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            var leavAllocations = await _context.LeaveAllocations.Where(q => q.EmployeeId == userId)
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leavAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leavAllocations = await _context.LeaveAllocations.Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
                

            return leavAllocations;
        }

        public async Task<LeaveAllocation> GetUserAllocationById(string userId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId
                                            && q.LeaveTypeId == leaveTypeId);
        }
    }
}
