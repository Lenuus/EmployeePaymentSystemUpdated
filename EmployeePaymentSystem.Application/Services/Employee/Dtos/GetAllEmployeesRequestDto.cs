using EmployeePaymentSystem.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application.Services.Employee.Dtos
{
    public class GetAllEmployeesRequestDto : PagedRequestDto
    {
        public string Search { get; set; } = string.Empty;
    }
}
