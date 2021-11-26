using System.ComponentModel.DataAnnotations.Schema;

namespace Leave_Management_NET6.Data
{
    public class LeaveAllocation
    {
        public int NumberOfDays { get; set; }
        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public string EmployeeId { get; set; }

    }
}
