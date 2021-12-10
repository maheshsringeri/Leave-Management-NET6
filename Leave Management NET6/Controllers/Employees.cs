using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Leave_Management_NET6.Data;
using Leave_Management_NET6.Constants;
using AutoMapper;
using Leave_Management_NET6.Models;
using Leave_Management_NET6.Contracts;
namespace Leave_Management_NET6.Controllers
{
    public class Employees : Controller
    {
        private readonly UserManager<Employee> userManager;
        private readonly IMapper mapper;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public Employees(UserManager<Employee> userManager, IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.leaveTypeRepository = leaveTypeRepository;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = await userManager.GetUsersInRoleAsync(Roles.User);

            var employeeListVM = mapper.Map<List<EmployeeListVM>>(employees);

            return View(employeeListVM);
        }

        // GET: Employees/ViewAllocations/EmployeeId
        public async Task<IActionResult> ViewAllocations(string id)
        {
            var model = await leaveAllocationRepository.GetEmployeeAllocations(id);
            return View(model);
        }


        // GET: Employees/EditAllocations/5
        public async Task<IActionResult> EditAllocations(int id)
        {
            var model = await leaveAllocationRepository.GetEmployeeAllocation(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        // POST: Employees/EditAllocations/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocations(int id, LeaveAllocationEditVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await leaveAllocationRepository.UpdateEmployeeAllocation(model))
                    {
                        return RedirectToAction(nameof(ViewAllocations), new { id = model.EmployeeId });
                    }
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "An Error Has Occurred, Please Try Again Latter.");
            }
            model.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(model.EmployeeId));
            model.LeaveType = mapper.Map<LeaveTypeVM>(await leaveTypeRepository.GetAsync(model.LeaveTypeID));
            return View(model);
        }

    }
}
