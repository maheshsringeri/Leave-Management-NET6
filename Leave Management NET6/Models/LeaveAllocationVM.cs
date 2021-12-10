using System.ComponentModel.DataAnnotations;

namespace Leave_Management_NET6.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public int id { get; set; }
        [Display(Name = "Number Of Days")]
        [Required]
        [Range(1, 50, ErrorMessage = "Number of days should between 1 to 50.")]
        public int NumberOfDays { get; set; }
        [Required]
        [Display(Name = "Allocation Period")]
        public int Period { get; set; }
        public LeaveTypeVM? LeaveType { get; set; }

    }
}