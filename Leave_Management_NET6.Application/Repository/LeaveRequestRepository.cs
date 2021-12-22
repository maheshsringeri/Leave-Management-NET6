using Leave_Management_NET6.Application.Contracts;
using Leave_Management_NET6.Data;
using Leave_Management_NET6.Common.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Http;

namespace Leave_Management_NET6.Application.Repository
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<Employee> userManager;
        private readonly AutoMapper.IConfigurationProvider configurationProvider;
        private readonly IEmailSender emailSender;

        public LeaveRequestRepository(ApplicationDbContext context, IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository,
            IHttpContextAccessor httpContextAccessor, UserManager<Employee> userManager,
            AutoMapper.IConfigurationProvider configurationProvider, IEmailSender emailSender) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.configurationProvider = configurationProvider;
            this.emailSender = emailSender;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;

            await UpdateAsync(leaveRequest);

            var user = await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            await emailSender.SendEmailAsync(user.Email, $"Leave Request Cancelled", $"You leave request from" +
                        $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been Cancelled Successfully");
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

            var user = await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            var approvalStatus = approved ? "Approved" : "Declined";

            await emailSender.SendEmailAsync(user.Email, $"Leave Request {approvalStatus}", $"Your leave request from " +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been {approvalStatus}");

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

            await emailSender.SendEmailAsync(user.Email, "Leave Request Submitted Successfully", $"Your leave request from " +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been submitted for approval");

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
                leaveRequest.NoOfDaysRequested = (int)(leaveRequest.EndDate.Value - leaveRequest.StartDate.Value).TotalDays + 1;
            }

            return model;
        }

        public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
        {

            return await context.leaveRequests
                        .Where(q => q.RequestingEmployeeId == employeeId)
                        .ProjectTo<LeaveRequestVM>(configurationProvider)
                        .ToListAsync();
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? Id)
        {
            var leaveRequest = await context.leaveRequests
                    .Include(q => q.LeaveType)
                    .ProjectTo<LeaveRequestVM>(configurationProvider)
                    .FirstOrDefaultAsync(q => q.Id == Id);

            if (leaveRequest == null)
                return null;

            leaveRequest.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));

            return leaveRequest;
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);

            var leaveAllocations = (await leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;

            var leaveRequests = await GetAllAsync(user.Id);

            foreach (var leaveRequest in leaveRequests)
            {
                leaveRequest.NoOfDaysRequested = (int)(leaveRequest.EndDate.Value - leaveRequest.StartDate.Value).TotalDays + 1;
            }

            var model = new EmployeeLeaveRequestViewVM(leaveAllocations, leaveRequests);

            return model;
        }
    }
}