using Leave_Management_NET6.Data;
using Leave_Management_NET6.Common.Models;
namespace Leave_Management_NET6.Application.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task LeaveAllocation(int leaveType);

        Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);

        Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId);

        Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId);

        Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id);

        Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model);

        Task<List<LeaveAllocationVM>> GetUserAllocatedLeaveTypes();
    }
}
