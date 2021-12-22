using System.ComponentModel.DataAnnotations;
namespace Leave_Management_NET6.Common.Models
{
    public class LeaveRequestVM : LeaveRequestCreateVM
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type")]
        public LeaveTypeVM LeaveType { get; set; }

        [Display(Name = "Date Requested")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateRequested { get; set; }

        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }

        [Display(Name = "# Of Days Requested")]
        public int? NoOfDaysRequested { get; set; }

        public string? RequestingEmployeeId { get; set; }
        public EmployeeListVM Employee { get; set; }

    }
}
