namespace Leave_Management_NET6.Common.Models
{
    public class LeaveAllocationEditVM : LeaveAllocationVM
    {
        public string EmployeeId { get; set; }
        public int LeaveTypeID { get; set; }
        public EmployeeListVM? Employee { get; set; }
    }
}
