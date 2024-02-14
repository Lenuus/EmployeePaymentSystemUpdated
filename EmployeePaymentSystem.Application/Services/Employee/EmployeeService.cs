using AutoMapper;
using EmployeePaymentSystem.Application.Services.Employee.Dtos;
using EmployeePaymentSystem.Common.Dto;
using EmployeePaymentSystem.Common.Helpers;
using EmployeePaymentSystem.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Domain.Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(
            IRepository<Domain.Employee> employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse<EmployeeDetailDto>> GetEmployeeById(Guid id)
        {
            var employee = await _employeeRepository.GetById(id).ConfigureAwait(false);
            if (employee == null)
            {
                return new ServiceResponse<EmployeeDetailDto>(null, false, "Not found.");
            }

            var response = _mapper.Map<EmployeeDetailDto>(employee);
            return new ServiceResponse<EmployeeDetailDto>(response, true, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse<PagedResponseDto<EmployeeListDto>>> GetAllEmployees(GetAllEmployeesRequestDto request)
        {
            var query = await _employeeRepository.GetAll()
                .Where(f => !f.IsDeleted && (!string.IsNullOrEmpty(request.Search) ? (f.Name + " " + f.Surname).Contains(request.Search) : true))
                .Select(f => new EmployeeListDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Surname = f.Surname,
                    Tckn = f.Tckn,
                    HiringDate = f.HiringDate,
                    FullName = (f.Name + " " + f.Surname)
                }).ToPagedListAsync(request.PageSize, request.PageIndex);

            return new ServiceResponse<PagedResponseDto<EmployeeListDto>>(query, true, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse> DeleteEmployee(Guid id)
        {
            try
            {
                await _employeeRepository.DeleteById(id).ConfigureAwait(false);
                return new ServiceResponse(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, ex.Message);
            }
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse> CreateEmployee(CreateEmployeeRequestDto request)
        {
            if (request == null)
            {
                return new ServiceResponse(false, "Lütfen formu doldurun");
            }

            var entity = _mapper.Map<Domain.Employee>(request);
            await _employeeRepository.Create(entity);
            return new ServiceResponse(true, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse> UpdateEmployee(UpdateEmployeeRequestDto request)
        {
            if (request == null)
            {
                return new ServiceResponse(false, "Lütfen formu doldurun");
            }

            var employee = await _employeeRepository.GetById(request.Id).ConfigureAwait(false);
            if (employee == null)
            {
                return new ServiceResponse(false, "Not Found");
            }

            employee.Name = request.Name;
            employee.Surname = request.Surname;
            employee.Tckn = request.Tckn;
            employee.HiringDate = request.HiringDate;
            await _employeeRepository.Update(employee);
            return new ServiceResponse(true, string.Empty);
        }
    }
}
