namespace Leave_Management_NET6.Common.Models
{
    public class EmployeeLeaveRequestViewVM
    {

        public EmployeeLeaveRequestViewVM(List<LeaveAllocationVM> leaveAllocations, List<LeaveRequestVM> leaveRequests)
        {
            LeaveAllocations = leaveAllocations;
            LeaveRequests = leaveRequests;
        }
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }



    }
}
