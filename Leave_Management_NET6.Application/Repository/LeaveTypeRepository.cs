using Leave_Management_NET6.Application.Contracts;
using Leave_Management_NET6.Data;

namespace Leave_Management_NET6.Application.Repository
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
