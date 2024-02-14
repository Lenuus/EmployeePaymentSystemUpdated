using AutoMapper;
using EmployeePaymentSystem.Application.Services.Employee.Dtos;
using EmployeePaymentSystem.Common.Dto;
using EmployeePaymentSystem.Web.Models;
using EmployeePaymentSystem.Web.Models.Employee;

namespace EmployeePaymentSystem.Web.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<IndexRequestModel, GetAllEmployeesRequestDto>();
            CreateMap<EmployeeListDto, IndexResponseModel>();
            CreateMap<CreateEmployeeRequestModel, CreateEmployeeRequestDto>();
            CreateMap<EmployeeDetailDto, UpdateEmployeeRequestModel>();
            CreateMap<UpdateEmployeeRequestModel, UpdateEmployeeRequestDto>();
            CreateMap<PagedResponseDto<EmployeeListDto>, PagedResponseModel<IndexResponseModel>>();
        }
    }
}
