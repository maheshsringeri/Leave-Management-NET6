using Leave_Management_NET6.Data;
using Leave_Management_NET6.Contracts;
using Microsoft.AspNetCore.Identity;
using Leave_Management_NET6.Constants;
using Microsoft.EntityFrameworkCore;
using Leave_Management_NET6.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Leave_Management_NET6.Repository
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<Employee> userManager;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;
        private readonly AutoMapper.IConfigurationProvider configurationProvider;

        public LeaveAllocationRepository(ApplicationDbContext context, UserManager<Employee> userManager,
            ILeaveTypeRepository leaveTypeRepository, IMapper mapper, AutoMapper.IConfigurationProvider configurationProvider) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
            this.configurationProvider = configurationProvider;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await context.leaveAllocations.AnyAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId && q.Period == period);
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await context.leaveAllocations
                                    .Include(q => q.LeaveType)
                                    .Where(q => q.EmployeeId == employeeId)
                                    .ProjectTo<LeaveAllocationVM>(configurationProvider)
                                    .ToListAsync();

            var employee = await userManager.FindByIdAsync(employeeId);

            var employeeAllocationModel = mapper.Map<EmployeeAllocationVM>(employee);
            employeeAllocationModel.LeaveAllocations = allocations;

            return employeeAllocationModel;
        }


        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id)
        {
            var allocation = await context.leaveAllocations
                                    .Include(q => q.LeaveType)
                                    .Where(q => q.Id == id)
                                    .ProjectTo<LeaveAllocationEditVM>(configurationProvider)
                                    .FirstOrDefaultAsync();

            if (allocation == null)
                return null;

            var employee = await userManager.FindByIdAsync(allocation.EmployeeId);
            
            allocation.Employee = mapper.Map<EmployeeListVM>(employee);

            return allocation;
        }


        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await leaveTypeRepository.GetAsync(leaveTypeId);

            var allocations = new List<LeaveAllocation>();

            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                    continue;

                allocations.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leaveType.DefaultDays
                });

            }

            await AddRangeAsync(allocations);

        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model)
        {
            var leaveAllocation = await GetAsync(model.id);
            if (leaveAllocation == null)
            {
                return false;
            }
            leaveAllocation.NumberOfDays = model.NumberOfDays;
            leaveAllocation.Period = model.Period;

            await UpdateAsync(leaveAllocation);
            return true;

        }

        public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            return await context.leaveAllocations
                            .Where(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId)
                            .FirstOrDefaultAsync();
        }
    }
}
