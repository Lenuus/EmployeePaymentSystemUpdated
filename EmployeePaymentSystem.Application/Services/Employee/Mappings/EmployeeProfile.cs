using AutoMapper;
using EmployeePaymentSystem.Application.Services.Employee.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application.Services.Employee.Mappings
{
    public class EmployeeProfile: Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeRequestDto, Domain.Employee>();
            CreateMap<Domain.Employee, EmployeeDetailDto>();
        }
    }
}
