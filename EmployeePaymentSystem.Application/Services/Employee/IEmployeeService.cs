using EmployeePaymentSystem.Application.Services.Employee.Dtos;
using EmployeePaymentSystem.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application.Services.Employee
{
    public interface IEmployeeService
    {
        /// <summary>
        /// GetEmployeeById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<EmployeeDetailDto>> GetEmployeeById(Guid id);

        /// <summary>
        /// Get All Employees based request data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse<PagedResponseDto<EmployeeListDto>>> GetAllEmployees(GetAllEmployeesRequestDto request);

        /// <summary>
        /// Delete Employe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse> DeleteEmployee(Guid id);

        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> CreateEmployee(CreateEmployeeRequestDto request);

        /// <summary>
        /// UpdateEmployee
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> UpdateEmployee(UpdateEmployeeRequestDto request);
    }
}
