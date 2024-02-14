using AutoMapper;
using EmployeePaymentSystem.Application.Services.Employee;
using EmployeePaymentSystem.Application.Services.Employee.Dtos;
using EmployeePaymentSystem.Common.Dto;
using EmployeePaymentSystem.Web.Models;
using EmployeePaymentSystem.Web.Models.Employee;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePaymentSystem.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(
            IEmployeeService employeeService,
            IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(IndexRequestModel model)
        {
            var request = _mapper.Map<GetAllEmployeesRequestDto>(model);
            var response = await _employeeService.GetAllEmployees(request).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                return NotFound();
            }

            var mappedResponse = _mapper.Map<PagedResponseModel<IndexResponseModel>>(response.Data);
            return View(mappedResponse);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var request = _mapper.Map<CreateEmployeeRequestDto>(model);
            var response = await _employeeService.CreateEmployee(request).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var employee = await _employeeService.GetEmployeeById(id).ConfigureAwait(false);
            if (!employee.IsSuccessful)
            {
                return NotFound();
            }

            var response = _mapper.Map<UpdateEmployeeRequestModel>(employee.Data);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, UpdateEmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var request = _mapper.Map<UpdateEmployeeRequestDto>(model);
            var response = await _employeeService.UpdateEmployee(request).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _employeeService.DeleteEmployee(id).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
