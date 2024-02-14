using AutoMapper;
using EmployeePaymentSystem.Application.Services.Employee.Dtos;
using EmployeePaymentSystem.Common.Dto;
using EmployeePaymentSystem.Web.Models;
using EmployeePaymentSystem.Web.Models.Employee;

namespace EmployeePaymentSystem.Web.Mappings
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<PagedRequestModel, PagedRequestDto>();
        }
    }
}
