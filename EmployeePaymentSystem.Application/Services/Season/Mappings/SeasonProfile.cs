using AutoMapper;
using EmployeePaymentSystem.Application.Services.Season.Dtos;

namespace EmployeePaymentSystem.Application.Services.Season.Mappings
{
    public class SeasonProfile: Profile
    {
        public SeasonProfile()
        {
            CreateMap<CreateSeasonRequestDto, Domain.Season>();
            CreateMap<Domain.Season, SeasonDetailDto>();
        }
    }
}
