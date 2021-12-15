using Leave_Management_NET6.Contracts;
using Leave_Management_NET6.Data;
using Leave_Management_NET6.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Leave_Management_NET6.Repository
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<Employee> userManager;

        public LeaveRequestRepository(ApplicationDbContext context, IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository,
            IHttpContextAccessor httpContextAccessor, UserManager<Employee> userManager) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;

            await UpdateAsync(leaveRequest);
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;

            if (approved)
            {
                var leaveAllovation = await leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                int dayRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                leaveAllovation.NumberOfDays -= dayRequested;

                await leaveAllocationRepository.UpdateAsync(leaveAllovation);
            }

            await UpdateAsync(leaveRequest);
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);

            var leaveAllocation = await leaveAllocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeId);
            if (leaveAllocation == null)
            {
                return false;
            }

            int daysRequested = (int)(model.EndDate.Value - model.StartDate.Value).TotalDays;

            if (daysRequested > leaveAllocation.NumberOfDays)
            {
                return false;
            }

            var leaveRequest = mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);


            return true;

        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            var leaveRequests = await context.leaveRequests.Include(q => q.LeaveType).ToListAsync();

            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
                PendingRequests = leaveRequests.Count(q => q.Approved == null),
                RejectedRequests = leaveRequests.Count(q => q.Approved == false),
                LeaveRequests = mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }

            return model;
        }

        public async Task<List<LeaveRequest>> GetAllAsync(string employeeId)
        {

            return await context.leaveRequests.Where(q => q.RequestingEmployeeId == employeeId).ToListAsync();
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? Id)
        {
            var leaveRequest = await context.leaveRequests
                    .Include(q => q.LeaveType)
                    .FirstOrDefaultAsync(q => q.Id == Id);

            if (leaveRequest == null)
                return null;

            var model = mapper.Map<LeaveRequestVM>(leaveRequest);

            model.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));

            return model;
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);

            var leaveAllocations = (await leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;

            var leaveRequests = mapper.Map<List<LeaveRequestVM>>(await GetAllAsync(user.Id));

            var model = new EmployeeLeaveRequestViewVM(leaveAllocations, leaveRequests);

            return model;
        }
    }
}