using AutoMapper;
using EmployeePaymentSystem.Application.Services.Employee.Dtos;
using EmployeePaymentSystem.Application.Services.Season.Dtos;
using EmployeePaymentSystem.Common.Dto;
using EmployeePaymentSystem.Web.Models;
using EmployeePaymentSystem.Web.Models.Season;

namespace EmployeePaymentSystem.Web.Mappings
{
    public class SeasonProfile : Profile
    {
        public SeasonProfile()
        {
            CreateMap<IndexRequestModel, GetAllSeasonsRequestDto>();
            CreateMap<SeasonListDto, IndexResponseModel>();
            CreateMap<CreateSeasonRequestModel, CreateSeasonRequestDto>();
            CreateMap<SeasonDetailDto, UpdateSeasonRequestModel>();
            CreateMap<UpdateSeasonRequestModel, UpdateSeasonRequestDto>();
            CreateMap<PagedResponseDto<SeasonListDto>, PagedResponseModel<IndexResponseModel>>();
        }
    }
}
