using Leave_Management_NET6.Contracts;
using Leave_Management_NET6.Data;

namespace Leave_Management_NET6.Repository
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
