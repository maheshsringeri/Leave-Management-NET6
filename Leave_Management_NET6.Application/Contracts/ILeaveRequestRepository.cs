using Leave_Management_NET6.Data;
using Leave_Management_NET6.Common.Models;

namespace Leave_Management_NET6.Application.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails();
        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? Id);
        Task<List<LeaveRequestVM>> GetAllAsync(string employeeId);
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();
        Task ChangeApprovalStatus(int leaveRequestId, bool approved);

        Task CancelLeaveRequest(int leaveRequestId);
    }
}
