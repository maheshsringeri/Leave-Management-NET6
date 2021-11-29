using System.ComponentModel.DataAnnotations;
namespace Leave_Management_NET6.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Display(Name = "Leave Type Name")]
        public string Name { get; set; }
        [Range(1, 25, ErrorMessage = "Default leave day's should between 1 to 25")]
        [Display(Name = "Default Number of Days")]
        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
